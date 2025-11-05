# Channel-based Pub/Sub Example Project

## Overview

This project demonstrates how to use .NET Channels to implement an efficient pub/sub pattern (publish/subscribe) that offloads a microservice through asynchronous event handling. The solution is particularly useful when you want to avoid blocking the main flow in your application while time-consuming operations are processed.

### Key Benefits

- **Offloading**: Time-consuming operations don't block the main process
- **Asynchronous communication**: Producer and consumer are decoupled
- **High performance**: Channels offer much more efficient performance than traditional queues
- **Backpressure handling**: Automatic handling of situations where consumers can't keep up
- **Type-safety**: Strong typing through generics
- **Scalability**: Easy to add more event handlers without changing existing code

## Architecture

### Component Overview

```
┌─────────────────┐
│     Worker      │  Producer: Generates domain events
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│   IEventBus     │  Abstraction layer for publishing
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│ InMemoryQueue   │  Channel-based queue 
│   (Channel)     │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│DomainEvents     │  Consumer: Reads from channel
│ProcessorJob     │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│    Dispatcher   │  Distributes events to correct handler
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│ Event Handlers  │  Handles specific event types
└─────────────────┘
```

## How It Works

### Data Flow

1. **Worker** (Producer) creates and publishes domain events
2. **IEventBus** writes events to the channel
3. **InMemoryMessageQueue** (Channel) buffers events
4. **DomainEventsProcessorJob** (Consumer) reads events from channel
5. **DomainEventDispatcher** finds and invokes the correct handlers
6. **Event Handlers** execute business logic for specific event types

### Key Components

| Component | Purpose | File |
|-----------|---------|------|
| **IDomainEvent** | Base interface for all events | `IDomainEvent.cs` |
| **InMemoryMessageQueue** | Channel wrapper (producer/consumer) | `InMemoryMessageQueue.cs` |
| **IEventBus / InMemoryEventBus** | Publisher abstraction and implementation | `InMemoryEventBus.cs` |
| **DomainEventsProcessorJob** | Background service that consumes events | `DomainEventsProcessorJob.cs` |
| **IDomainEventDispatcher** | Finds and executes handlers | `DomainEventDispatcher.cs` |
| **IDomainEventHandler<T>** | Generic handler interface | `IDomainEventHandler.cs` |
| **Event Handlers** | Specific business logic per event type | `DomainEventSampleEventHandler.cs` |


## Key Concepts

### Why Channels?

- **Lock-free** for single producer/single consumer scenarios
- **Async-first** design - doesn't block threads
- **Built-in backpressure** support
- **High performance** - much faster than `BlockingCollection<T>`

