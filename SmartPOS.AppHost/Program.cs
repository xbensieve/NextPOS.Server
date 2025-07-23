var builder = DistributedApplication.CreateBuilder(args);

var authService = builder.AddProject<Projects.AuthService_Api>("auth")
    .WithEndpoint("https", e => e.Port = 8000);

var customerService = builder.AddProject<Projects.CustomerService_Api>("customers")
    .WithEndpoint("https", e => e.Port = 8001);

var inventoryService = builder.AddProject<Projects.InventoryService_Api>("inventories")
    .WithEndpoint("https", e => e.Port = 8002);

var orderService = builder.AddProject<Projects.OrderService_Api>("orders")
    .WithEndpoint("https", e => e.Port = 8003);

var paymentService = builder.AddProject<Projects.PaymentService_Api>("payments")
    .WithEndpoint("https", e => e.Port = 8004);

var productService = builder.AddProject<Projects.ProductService_Api>("products")
    .WithEndpoint("https", e => e.Port = 8005);

var reportService = builder.AddProject<Projects.ReportService_Api>("reports")
    .WithEndpoint("https", e => e.Port = 8006);

var gateway = builder.AddProject<Projects.ApiGateway_Api>("gateway")
    .WithEndpoint("https", e => e.Port = 5000)
    .WithReference(authService)
    .WithReference(customerService)
    .WithReference(inventoryService)
    .WithReference(orderService)
    .WithReference(paymentService)
    .WithReference(productService)
    .WithReference(reportService);


builder.Build().Run();
