using danone_client.Models.DTOs;
using danone_client.Models.Entities;
using danone_client.Models.Responses;
using danone_client.Repositories.Interfaces;
using Microsoft.OpenApi.Any;

namespace danone_client.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public Response GetById(int id)
        {
            Response response = new Response();

            var product = _productsRepository.GetById(id);

            ProductDTO result = new ProductDTO(product);

            return new ResponseModel<ProductDTO>(200, "Ok", result);
        }

        public Response GetAllByBrand()
        {
            Response response = new Response();

            var serenito = _productsRepository.GetByBrand("Serenito");
            var danette = _productsRepository.GetByBrand("Danette");
            var danonino = _productsRepository.GetByBrand("Danonino");
            var yogurisimo = _productsRepository.GetByBrand("Yogurisimo");
            var ser = _productsRepository.GetByBrand("Ser");
            var activia = _productsRepository.GetByBrand("Activia");
            var actimel = _productsRepository.GetByBrand("Actimel");
            var lsc = _productsRepository.GetByBrand("La Serenísma Clásico");
            var casancrem = _productsRepository.GetByBrand("Casancrem");
            var cindor = _productsRepository.GetByBrand("Cindor");
            var silk = _productsRepository.GetByBrand("Silk");
            var granCompra = _productsRepository.GetByBrand("Gran Compra");

            var products = new List<BrandDTO>();
            products.Add(new BrandDTO
            {
                name = "Serenito",
                products = serenito.Select(p => new ProductDTO(p)).ToList()
            });
            products.Add(new BrandDTO
            {
                name = "Danette",
                products = danette.Select(p => new ProductDTO(p)).ToList()
            });
            products.Add(new BrandDTO
            {
                name = "Danonino",
                products = danonino.Select(p => new ProductDTO(p)).ToList()
            });
            products.Add(new BrandDTO
            {
                name = "Yogurisimo",
                products = yogurisimo.Select(p => new ProductDTO(p)).ToList()
            });
            products.Add(new BrandDTO
            {
                name = "Ser",
                products = ser.Select(p => new ProductDTO(p)).ToList()
            });
            products.Add(new BrandDTO
            {
                name = "Activia",
                products = activia.Select(p => new ProductDTO(p)).ToList()
            });
            products.Add(new BrandDTO
            {
                name = "Actimel",
                products = actimel.Select(p => new ProductDTO(p)).ToList()
            });
            products.Add(new BrandDTO
            {
                name = "La Serenísma Clásico",
                products = lsc.Select(p => new ProductDTO(p)).ToList()
            });
            products.Add(new BrandDTO
            {
                name = "Casancrem",
                products = casancrem.Select(p => new ProductDTO(p)).ToList()
            });
            products.Add(new BrandDTO
            {
                name = "Cindor",
                products = cindor.Select(p => new ProductDTO(p)).ToList()
            });
            products.Add(new BrandDTO
            {
                name = "Silk",
                products = silk.Select(p => new ProductDTO(p)).ToList()
            });
            products.Add(new BrandDTO
            {
                name = "Gran Compra",
                products = granCompra.Select(p => new ProductDTO(p)).ToList()
            });


            return new ResponseModel<List<BrandDTO>>(200, "Ok", products);
        }

        public Response GetAll()
        {
            Response response = new Response();

            var serenito = _productsRepository.GetByBrand("Serenito");
            var danette = _productsRepository.GetByBrand("Danette");
            var danonino = _productsRepository.GetByBrand("Danonino");
            var yogurisimo = _productsRepository.GetByBrand("Yogurisimo");
            var ser = _productsRepository.GetByBrand("Ser");
            var activia = _productsRepository.GetByBrand("Activia");
            var actimel = _productsRepository.GetByBrand("Actimel");
            var lsc = _productsRepository.GetByBrand("La Serenísma Clásico");
            var casancrem = _productsRepository.GetByBrand("Casancrem");
            var cindor = _productsRepository.GetByBrand("Cindor");
            var silk = _productsRepository.GetByBrand("Silk");
            var granCompra = _productsRepository.GetByBrand("Gran Compra");

            var products = new List<Product>();

            foreach (var product in serenito) products.Add(product);
            foreach (var product in danette) products.Add(product);
            foreach (var product in danonino) products.Add(product);
            foreach (var product in yogurisimo) products.Add(product);
            foreach (var product in ser) products.Add(product);
            foreach (var product in activia) products.Add(product);
            foreach (var product in actimel) products.Add(product);
            foreach (var product in lsc) products.Add(product);
            foreach (var product in casancrem) products.Add(product);
            foreach (var product in cindor) products.Add(product);
            foreach (var product in silk) products.Add(product);
            foreach (var product in granCompra) products.Add(product);

            if (products == null)
            {
                response.statusCode = 404;
                response.message = "Not Found";
                return response;
            }
            List<ProductDTO> result = new List<ProductDTO>();

            foreach (var product in products)
            {
                result.Add(new ProductDTO(product));
            }

            return new ResponseModel<List<ProductDTO>>(200, "Ok", result);
        }


        public Response GetByBrand(string brand)
        {
            Response response = new Response();

            var products = _productsRepository.GetByBrand(brand);

            if (products == null)
            {
                response.statusCode = 404;
                response.message = "Not Found";
                return response;
            }
            List<ProductDTO> result = new List<ProductDTO>();

            foreach (var product in products)
            {
                result.Add(new ProductDTO(product));
            }

            return new ResponseModel<List<ProductDTO>>(200, "Ok", result);
        }

        public Response Add(AddProductDTO model)
        {
            Response response = new Response();

            Product product = new Product
            {
                universalCode = model.universalCode,
                sku = model.sku,
                description = model.description,
                imageUrl = model.imageUrl,
                brand = model.brand
            };

            _productsRepository.Save(product);

            response.statusCode = 200;
            response.message = "Ok";
            return response;
        }

        public Response Update(ProductDTO model)
        {
            Response response = new Response();

            var product = _productsRepository.GetById(model.Id);

            if (product == null)
            {
                response.statusCode = 404;
                response.message = "Not Found";
                return response;
            }

            product.universalCode = model.universalCode;
            product.sku = model.sku;
            product.description = model.description;
            product.imageUrl = model.imageUrl;
            product.brand = model.brand;

            _productsRepository.Save(product);

            response.statusCode = 200;
            response.message = "Ok";
            return response;
        }

        public Response Delete(int id)
        {
            Response response = new Response();

            var product = _productsRepository.GetById(id);

            if (product == null)
            {
                response.statusCode = 404;
                response.message = "Not Found";
                return response;
            }

            _productsRepository.Remove(product);

            response.statusCode = 200;
            response.message = "Ok";
            return response;
        }
    }

}

