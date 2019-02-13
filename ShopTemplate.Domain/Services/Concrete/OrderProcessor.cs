using ShopTemplate.Domain.Models.Entities;
using ShopTemplate.Domain.Services.Abstract;
using ShopTemplate.Domain.Services.Abstract.Utils;
using ShopTemplate.Domain.Services.Concrete.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopTemplate.Domain.Services.Concrete
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IEmailSender emailSender;
        private readonly IProductRepository productRepository;
        private readonly IRatesRepository ratesRepository;
        private readonly IOrderRepository orderRepository;
        private readonly ApplicationUserManager applicationUserManager;

        public OrderProcessor(IOrderRepository orderRepository, IEmailSender emailSender, IRatesRepository ratesRepository,
            IProductRepository productRepository, ApplicationUserManager applicationUserManager)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.emailSender = emailSender;
            this.ratesRepository = ratesRepository;
            this.applicationUserManager = applicationUserManager;
        }

        public async Task ProcessAsync(Order order, string baseUrl)
        {
            await orderRepository.AddAsync(order);
            await SendNewOrderEmailAsync(order, baseUrl);
            await SavePendingRatesAsync(order);
        }

        private async Task SendNewOrderEmailAsync(Order order, string baseUrl)
        {
            List<Product> products = new List<Product>();
            order.ProductOrders.ForEach(p => 
            {
                products.Add(p.Product);
            });

            await emailSender.SendOrderPlacedAsync(await applicationUserManager.GetUserEmailByIdAsync(order.User.Id),
                order, products, baseUrl);
        }

        private async Task SavePendingRatesAsync(Order order)
        {
            foreach (ProductOrder productOrder in order.ProductOrders)
            {
                PendingRate pendingRate = new PendingRate(productOrder.Product, order.User.Id, order.Date);
                await ratesRepository.AddPendingAsync(pendingRate);
            }
        }
    }
}
