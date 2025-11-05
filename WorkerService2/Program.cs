using WorkerService2;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<InMemoryMessageQueue>();
builder.Services.AddSingleton<IEventBus, InMemoryEventBus>();
builder.Services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();

builder.Services.AddSingleton<IDomainEventHandler<DomainEventSample1>, DomainEventSample1EventHandler>();
builder.Services.AddSingleton<IDomainEventHandler<DomainEventSample2>, DomainEventSample2EventHandler>();

builder.Services.AddHostedService<DomainEventsProcessorJob>();

var host = builder.Build();
host.Run();
