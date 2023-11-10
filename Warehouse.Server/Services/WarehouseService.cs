using Grpc.Core;

namespace Warehouse.Server.Services
{
    public class WarehouseService : Warehouse.WarehouseBase
    {
        private static Dictionary<string, Product> _products = new Dictionary<string, Product>();
        public override Task<Product> GetProductById(ProductID request, ServerCallContext context)
        {
            if (_products.TryGetValue(request.Id, out Product? product) && product != null)
            {
                return Task.FromResult(product);
            }
            else
            {
                var errrorResponse = new ErrorResponse
                {
                    Reason = "Product not found.",
                    Details = { $"No product with ID: {request.Id} exists." }
                };
                context.Status = new Status(StatusCode.NotFound, $"{errrorResponse.Reason}. Detail: {errrorResponse.Details}");
                return Task.FromResult(new Product());
            }
        }

        public override Task<Product> GetProductByName(ProductName request, ServerCallContext context)
        {
            Product matchingProduct = null;
            foreach (var product in _products.Values)
            {
                if (product.Name == request.Name)
                {
                    matchingProduct = product;
                    break;
                }
            }
            if (matchingProduct == null)
            {
                var errrorResponse = new ErrorResponse
                {
                    Reason = "Product not found.",
                    Details = { $"No product with Name: {request.Name} exists." }
                };
                context.Status = new Status(StatusCode.NotFound, $"{errrorResponse.Reason}. Detail: {errrorResponse.Details}");
                return Task.FromResult(new Product());
            }
            else
            {
                return Task.FromResult(matchingProduct);
            }
        }

        public override Task<ProductID> AddProduct(Product request, ServerCallContext context)
        {
            _products[request.Id] = request;
            return Task.FromResult(new ProductID { Id = request.Id });
        }

        public override Task<Product> UpdateProduct(Product request, ServerCallContext context)
        {
            if (_products.ContainsKey(request.Id))
            {
                _products[request.Id] = request;
                return Task.FromResult(request);
            }
            else
            {
                var errrorResponse = new ErrorResponse
                {
                    Reason = "Product not found.",
                    Details = { $"No product with ID: {request.Name} exists." }
                };
                context.Status = new Status(StatusCode.NotFound, $"{errrorResponse.Reason}. Detail: {errrorResponse.Details}");
                return Task.FromResult(new Product());
            }
        }
    }
}