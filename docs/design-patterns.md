# Design Patterns

---

## Creational Patterns — Object Creation Strategies

---

### 🔒 Singleton Pattern

The Singleton pattern ensures that a class has only one instance, and provides a global access point to it.

**✅ Common Use Cases**

- Configuration managers
- Logging utilities
- Thread pools
- Caching
- Connection pools

**🛠 Core Implementation in C#:**

```csharp
public sealed class Singleton
{
    private static readonly Lazy<Singleton> instance =
        new Lazy<Singleton>(() => new Singleton());

    private Singleton() { }

    public static Singleton Instance => instance.Value;
}
```

- `Lazy<T>` ensures thread safety and lazy initialization.
- `sealed` prevents subclassing.
- The constructor is private to block external instantiation.

**⚠️ Pros vs Cons**

| Pros | Cons |
|------|------|
| Controlled access to shared state | Hidden dependencies & global state |
| Reduces memory footprint | Difficult to unit test & mock |
| Thread-safe (with Lazy) | Risk of tight coupling |

**🔍 In Modern Architectures**
In dependency injection-heavy environments (like ASP.NET Core), singletons are often declared via DI:

```csharp
services.AddSingleton<IMyService, MyService>();
```

This is a better approach as it avoids static access and preserves testability.

**💬 Thought for Distributed Systems**
In distributed environments (e.g., Orleans or microservices), true singletons don’t exist across node boundaries. Instead, you model them as virtual actors, centralized services, or use Redis/in-memory caches carefully. The singleton becomes logical, not physical.

---

### 🏭 Factory Method Pattern

Rather than instantiating objects directly, the Factory Method delegates the instantiation to subclasses or implementing types. This enables a flexible object creation strategy without binding the client code to specific concrete classes.

**💡 Basic Structure**

```csharp
public abstract class Document
{
    public abstract void Print();
}

public class PdfDocument : Document
{
    public override void Print() => Console.WriteLine("Printing PDF");
}

public class WordDocument : Document
{
    public override void Print() => Console.WriteLine("Printing Word Doc");
}

public abstract class DocumentCreator
{
    public abstract Document CreateDocument();
}

public class PdfCreator : DocumentCreator
{
    public override Document CreateDocument() => new PdfDocument();
}

public class WordCreator : DocumentCreator
{
    public override Document CreateDocument() => new WordDocument();
}
```

Client code calls `CreateDocument()` without knowing what specific type it's using — polymorphic instantiation FTW!

**🤖 Real-World Example: Orleans Grain Factory**

In distributed environments like Orleans:

- You don’t instantiate grains directly.
- You rely on a grain factory (`IGrainFactory`) to create proxy objects that represent the grains.
- This maintains separation of concerns and allows flexible routing, activation, and state management.

```csharp
var myGrain = grainFactory.GetGrain<IMyGrain>(key);
```

Behind the scenes, the actual object instantiation is abstracted away — a classic Factory Method.

**🔍 Key Benefits**

| ✅ Advantage | ⚠️ Risk |
|--------------|---------|
| Decouples object creation | Overhead of subclass proliferation |
| Improves extensibility | Might require complex hierarchies |
| Promotes interface-based design | Added complexity for simple cases |

---

### 🏭 Abstract Factory Pattern

The Abstract Factory provides an interface for creating related objects (often across multiple factories), ensuring consistency without binding the code to specific implementations.

**🔧 Key Concept:**  
A factory of factories — producing objects that belong to the same theme or “family.”

**💡 C# Example: UI Toolkit Factory**

```csharp
// Product Interfaces
public interface IButton { void Render(); }
public interface ICheckbox { void Render(); }

// Concrete Products - Windows
public class WindowsButton : IButton
{
    public void Render() => Console.WriteLine("Rendering Windows button");
}
public class WindowsCheckbox : ICheckbox
{
    public void Render() => Console.WriteLine("Rendering Windows checkbox");
}

// Concrete Products - Mac
public class MacButton : IButton
{
    public void Render() => Console.WriteLine("Rendering Mac button");
}
public class MacCheckbox : ICheckbox
{
    public void Render() => Console.WriteLine("Rendering Mac checkbox");
}

// Abstract Factory
public interface IUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete Factories
public class WindowsUIFactory : IUIFactory
{
    public IButton CreateButton() => new WindowsButton();
    public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}
public class MacUIFactory : IUIFactory
{
    public IButton CreateButton() => new MacButton();
    public ICheckbox CreateCheckbox() => new MacCheckbox();
}
```

Client code can swap factories without altering logic — preserving compatibility between components.

**🚀 Real-World Applications**

- UI rendering across platforms
- Database providers (SQL vs NoSQL drivers)
- Cloud service connectors (AWS vs Azure)
- Messaging formats (JSON vs Protobuf)
- Kubernetes resource generators (YAML-based factories)

**🧪 Testability Tip**
You can easily mock abstract factories to inject controlled behavior — clean for unit testing and mocking object families.

**🔄 Abstract Factory vs Factory Method**

| Aspect | Factory Method | Abstract Factory |
|--------|---------------|-----------------|
| Scope | Single object | Family of related objects |
| Structure | Involves inheritance | Often involves interface composition |
| Use Case | When one product is varied | When multiple products must remain compatible |
| Flexibility | Moderate | High — supports pluggable families |

---

### 🏗️ Builder Pattern

The Builder separates object construction from its representation. It’s especially handy when:

- You need to create many variations of an object.
- The object requires a multi-step creation process.
- You want to decouple creation logic from the final product.

**💡 Example: Fluent Builder in C#**

```csharp
public class Report
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public bool IncludeSummary { get; private set; }

    private Report() { }

    public class Builder
    {
        private readonly Report report = new();

        public Builder SetTitle(string title)
        {
            report.Title = title;
            return this;
        }

        public Builder SetAuthor(string author)
        {
            report.Author = author;
            return this;
        }

        public Builder WithSummary()
        {
            report.IncludeSummary = true;
            return this;
        }

        public Report Build() => report;
    }
}
```

Usage:

```csharp
var report = new Report.Builder()
    .SetTitle("Quarterly Metrics")
    .SetAuthor("Sergii Chevkota")
    .WithSummary()
    .Build();
```

The fluent API makes the code intuitive and readable — especially when creating highly configurable objects.

**🚀 Real-World Use Cases**

- Configuration builders (e.g., WebHostBuilder or HostBuilder in .NET)
- HTTP request builders (e.g., HttpRequestMessage.Builder)
- Immutable object creation where constructor overloads would be overwhelming
- ORM setup, query builders, and cloud SDK configuration (like AWS or Azure SDKs)

**🧠 Benefits**

| ✅ Advantages | ⚠️ Trade-Offs |
|--------------|--------------|
| Cleaner, readable object creation | Slightly more verbose than constructors |
| Simplifies optional/configurable logic | Can introduce extra boilerplate |
| Promotes immutability and clarity | Might be overkill for simple objects |

**🔗 Relation to Other Patterns**

- Factory creates objects all-at-once. Builder creates them step-by-step.
- Often used together: Factory produces a builder, or Builder wraps internal factory calls.

---

### 🧬 Prototype Pattern

The Prototype pattern allows you to create new objects by cloning existing ones, rather than instantiating from scratch. It relies on a `Clone()` method or interface to duplicate the object’s internal state.

**💡 C# Implementation (Using ICloneable)**

```csharp
public abstract class Shape : ICloneable
{
    public string Color { get; set; }

    public abstract object Clone();
}

public class Circle : Shape
{
    public int Radius { get; set; }

    public override object Clone()
    {
        return new Circle
        {
            Color = this.Color,
            Radius = this.Radius
        };
    }
}
```

Usage:

```csharp
var original = new Circle { Color = "Red", Radius = 10 };
var clone = (Circle)original.Clone();
```

Each clone is a new instance, but retains the structure and values of the original.

**🚀 Real-World Use Cases**

- UI element duplication in design software (e.g., Sketch, Figma)
- Configuration templates in cloud or microservice deployments
- Game development, where multiple entities share traits
- Data modeling, for pre-populated forms or payload stubs
- Simulation engines, where prototypes represent reusable states

**🔍 Pros and Trade-offs**

| ✅ Advantages | ⚠️ Limitations |
|--------------|---------------|
| Avoids expensive instantiation | Deep cloning can be tricky |
| Preserves internal structure/state | Risk of side effects if state isn't isolated |
| Flexible and dynamic object creation | Adds complexity to class hierarchy |

**🔧 Deep vs Shallow Copy**

- Shallow: Copies references — modifications affect both objects.
- Deep: Recursively copies all nested objects — complete independence.

Depending on your system’s complexity (say, graph of Kubernetes resources or nested Orleans state objects), deep cloning might be necessary for isolation.

---

## Structural Patterns — Object Composition Techniques

---

### 🧩 Adapter Pattern

**Bridge between incompatible interfaces**  
Purpose: Converts one interface into another so classes with incompatible interfaces can work together.

**💡 Example: C# Adapter**

```csharp
public interface ITarget
{
    void Request();
}

public class Adaptee
{
    public void SpecificRequest() => Console.WriteLine("Called SpecificRequest");
}

public class Adapter : ITarget
{
    private readonly Adaptee adaptee;

    public Adapter(Adaptee adaptee) => this.adaptee = adaptee;

    public void Request() => adaptee.SpecificRequest();
}
```

Useful when integrating legacy systems or third-party APIs with modern interfaces.

---

### 🌟 Bridge Pattern

**Decouple abstraction from implementation**  
Purpose: Separates an abstraction from its implementation so the two can evolve independently.

**💡 Example**

```csharp
public interface IMessageSender
{
    void Send(string message);
}

public class EmailSender : IMessageSender
{
    public void Send(string message) => Console.WriteLine($"Email: {message}");
}

public class Notification
{
    protected readonly IMessageSender sender;

    public Notification(IMessageSender sender) => this.sender = sender;

    public virtual void Notify(string message) => sender.Send(message);
}
```

You can swap out implementations (Email, SMS, Push) while keeping the abstraction stable.

---

### 🧱 Composite Pattern

**Hierarchical tree structure**  
Purpose: Treats individual objects and compositions uniformly — perfect for recursive structures.

**💡 Example**

```csharp
public interface IComponent
{
    void Operation();
}

public class Leaf : IComponent
{
    public void Operation() => Console.WriteLine("Leaf operation");
}

public class Composite : IComponent
{
    private readonly List<IComponent> children = new();

    public void Add(IComponent child) => children.Add(child);

    public void Operation()
    {
        Console.WriteLine("Composite operation:");
        children.ForEach(c => c.Operation());
    }
}
```

Great for menus, file systems, or UI layouts.

---

### 🧙 Decorator Pattern

**Add behavior without modifying original class**  
Purpose: Dynamically adds responsibilities to objects without altering their structure.

**💡 Example**

```csharp
public interface INotifier
{
    void Send(string message);
}

public class BasicNotifier : INotifier
{
    public void Send(string message) => Console.WriteLine(message);
}

public class SMSDecorator : INotifier
{
    private readonly INotifier wrapped;

    public SMSDecorator(INotifier wrapped) => this.wrapped = wrapped;

    public void Send(string message)
    {
        wrapped.Send(message);
        Console.WriteLine($"SMS: {message}");
    }
}
```

Used heavily in logging, metrics, or feature toggles.

---

### 🧥 Facade Pattern

**Simplify access to a complex system**  
Purpose: Provides a unified interface to a set of interfaces in a subsystem.

**💡 Example**

```csharp
public class Compiler { public void Compile() => Console.WriteLine("Compiling..."); }
public class Linker { public void Link() => Console.WriteLine("Linking..."); }

public class BuildFacade
{
    private readonly Compiler compiler = new();
    private readonly Linker linker = new();

    public void Build()
    {
        compiler.Compile();
        linker.Link();
    }
}
```

Commonly used in SDKs, APIs, or library wrappers to abstract complexity.

---

### 🔐 Proxy Pattern

**Control access or add indirection**  
Purpose: Provides a surrogate for another object to control access or augment behavior.

**💡 Example: Remote Proxy**

```csharp
public interface IService
{
    void Execute();
}

public class RealService : IService
{
    public void Execute() => Console.WriteLine("Service Executed");
}

public class ProxyService : IService
{
    private RealService realService;

    public void Execute()
    {
        if (realService == null)
            realService = new RealService();

        Console.WriteLine("Proxy logic before execution");
        realService.Execute();
    }
}
```

Used in caching, lazy loading, access control, and remote invocation (e.g. Orleans grains or WCF).

---

## Behavioral Design Patterns

---

### 🧠 Strategy Pattern

**Encapsulate interchangeable behaviors**  
Enables selecting an algorithm or behavior at runtime — ideal when multiple strategies exist for a task.

**💡 C# Example: Payment Processor**

```csharp
public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount) => Console.WriteLine($"Paid {amount} via Credit Card");
}

public class PaypalPayment : IPaymentStrategy
{
    public void Pay(decimal amount) => Console.WriteLine($"Paid {amount} via PayPal");
}

public class PaymentContext
{
    private IPaymentStrategy strategy;

    public void SetStrategy(IPaymentStrategy strategy) => this.strategy = strategy;

    public void ExecutePayment(decimal amount) => strategy.Pay(amount);
}
```

**🚀 Use Cases**

- Sorting algorithms
- Routing logic (e.g., by region or tenant)
- Pricing or discount rules

**🔍 Pros vs Cons**

| ✅ Advantage | ⚠️ Trade-Off |
|--------------|-------------|
| Promotes open/closed design | Slightly more setup |
| Swappable logic | Might over-abstract small tasks |

---

### 🔔 Observer Pattern

**Publish/subscribe mechanism**  
Establishes a one-to-many dependency where observers are notified automatically when the subject changes.

**💡 C# Example: Stock Ticker**

```csharp
public interface IObserver
{
    void Update(decimal price);
}

public class Investor : IObserver
{
    public void Update(decimal price) => Console.WriteLine($"New stock price: {price}");
}

public class Stock
{
    private readonly List<IObserver> observers = new();
    public void Attach(IObserver observer) => observers.Add(observer);
    public void Notify(decimal price) => observers.ForEach(o => o.Update(price));
}
```

**🚀 Use Cases**

- UI bindings (e.g., MVVM)
- Event-driven systems
- Real-time dashboards

**🔍 Pros vs Cons**

| ✅ Advantage | ⚠️ Trade-Off |
|--------------|-------------|
| Decouples publisher/subscriber | Can lead to notification storms |
| Promotes reactive architecture | Hard to debug cascade effects |

---

### 🧾 Command Pattern

**Encapsulate a request as an object**  
Encapsulates requests as objects, enabling undo/redo, logging, or queuing.

**💡 C# Example: Undo System**

```csharp
public interface ICommand
{
    void Execute();
    void Undo();
}

public class TextCommand : ICommand
{
    private string text;

    public TextCommand(string text) => this.text = text;

    public void Execute() => Console.WriteLine($"Writing: {text}");
    public void Undo() => Console.WriteLine($"Removing: {text}");
}
```

**🚀 Use Cases**

- UI actions
- Task queues or job runners
- Workflow orchestration

**🔍 Pros vs Cons**

| ✅ Advantage | ⚠️ Trade-Off |
|--------------|-------------|
| Supports undo/redo/history | Adds boilerplate overhead |
| Command queueing & scheduling | Needs careful state tracking |

---

### 📄 Template Method Pattern

**Define skeleton with customizable steps**  
Defines the overall structure of an algorithm while deferring some steps to subclasses.

**💡 C# Example: Data Exporter**

```csharp
public abstract class DataExporter
{
    public void Export()
    {
        Connect();
        WriteHeader();
        WriteData();
        Disconnect();
    }

    protected abstract void Connect();
    protected abstract void WriteData();
    protected virtual void WriteHeader() => Console.WriteLine("Header written");
    protected virtual void Disconnect() => Console.WriteLine("Disconnected");
}
```

**🚀 Use Cases**

- Framework methods with extensibility
- Invariant orchestration pipelines
- Report generation

**🔍 Pros vs Cons**

| ✅ Advantage | ⚠️ Trade-Off |
|--------------|-------------|
| Reuse common logic | Requires inheritance |
| Easy to define workflow | Can lead to deep hierarchies |

---

### 🔗 Chain of Responsibility Pattern

**Pass request through chain**  
Passes requests along a chain of handlers until one processes it.

**💡 C# Example: Support System**

```csharp
public abstract class SupportHandler
{
    protected SupportHandler next;

    public void SetNext(SupportHandler next) => this.next = next;

    public abstract void Handle(string request);
}

public class BasicSupport : SupportHandler
{
    public override void Handle(string request)
    {
        if (request == "basic")
            Console.WriteLine("Handled by Basic Support");
        else
            next?.Handle(request);
    }
}
```

**🚀 Use Cases**

- Middleware chains (HTTP, gRPC, message brokers)
- Authentication pipelines
- Error handling

**🔍 Pros vs Cons**

| ✅ Advantage | ⚠️ Trade-Off |
|--------------|-------------|
| Flexible processing chains | Can be hard to trace request flow |
| Easy extension or override | Can become inefficient if chain grows too long |

---

### 🎭 State Pattern

**Alter behavior based on internal state**  
Allows an object to change its behavior dynamically when its state changes.

**💡 C# Example: Media Player**

```csharp

public interface IState
{
    void Play(MediaPlayer context);
}

public class PlayingState : IState
{
    public void Play(MediaPlayer context)
    {
        Console.WriteLine("Already playing");
    }
}

public class PausedState : IState
{
    public void Play(MediaPlayer context)
    {
        Console.WriteLine("Resuming playback");
        context.State = new PlayingState();
    }
}

public class MediaPlayer
{
    public IState State { get; set; } = new PausedState();

    public void PressPlay() => State.Play(this);
}
```

**🚀 Use Cases**

- Workflow engines
- UI toggling behavior
- Protocol state machines (e.g., WebSocket lifecycle)

**🔍 Pros vs Cons**

| ✅ Advantage | ⚠️ Trade-Off |
|--------------|-------------|
| Clean state handling logic | State proliferation across classes |
| No complex conditionals | Might over-engineer simple toggles |

---

### 🧳 Visitor Pattern

**Extend behavior across object structure**  
Separates algorithms from object structures so new operations can be added without modifying objects.

**💡 Example: Tax Calculation**

```csharp
public interface IVisitable
{
    void Accept(IVisitor visitor);
}

public interface IVisitor
{
    void Visit(FoodItem item);
    void Visit(ElectronicItem item);
}

public class FoodItem : IVisitable
{
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class TaxVisitor : IVisitor
{
    public void Visit(FoodItem item) => Console.WriteLine("Food tax applied");
    public void Visit(ElectronicItem item) => Console.WriteLine("Electronics tax applied");
}
```

**🚀 Use Cases**

- AST traversal (compilers)
- Tax/discount rules
- Runtime analytics & auditing

**🔍 Pros vs Cons**

| ✅ Advantage | ⚠️ Trade-Off |
|--------------|-------------|
| Open for new behaviors | Requires rigid structure for visiting |
| Keeps data and logic separate | Adds overhead to object definitions |

---

## Advanced Architectural Patterns

---

### 🧭 CQRS Pattern: Overview

CQRS (Command Query Responsibility Segregation) is a powerful architectural pattern, especially for distributed systems and applications that need scalability, high performance, or auditability.

CQRS separates read operations (queries) from write operations (commands) — letting each evolve independently.

> "Reads are not Commands. Writes are not Queries."

This division allows optimization of each side individually, e.g., high-throughput, denormalized reads versus transactional, validated writes.

**🔧 Core Components**

| Component | Role |
|-----------|------|
| Command | Intent to modify state, e.g., CreateOrder, CancelOrder |
| Command Handler | Executes business logic and writes to DB |
| Query | Request for data, e.g., GetOrderById, ListOrders |
| Query Handler | Reads data from DB or cache |
| Domain Model | Encapsulates write-side logic, often using DDD |
| Read Model | Optimized data structure for fast queries |

Often paired with event sourcing, where commands mutate the system by emitting events, and read models subscribe to them.

**💡 .NET Example (Simplified)**

```csharp
// Command
public record CreateOrderCommand(Guid OrderId, string Product);

// Command Handler
public class CreateOrderHandler : ICommandHandler<CreateOrderCommand>
{
    public Task Handle(CreateOrderCommand command)
    {
        // business logic
        // persist order
        return Task.CompletedTask;
    }
}

// Query
public record GetOrderQuery(Guid OrderId);

// Query Handler
public class GetOrderHandler : IQueryHandler<GetOrderQuery, OrderDto>
{
    public Task<OrderDto> Handle(GetOrderQuery query)
    {
        // fetch from read DB or view
        return Task.FromResult(new OrderDto(query.OrderId, "ProductName"));
    }
}
```

**🚀 Real-World Applications**

- High-volume ordering systems (e.g., e-commerce)
- Distributed microservice ecosystems
- Event-driven data pipelines
- Audit trail and compliance domains
- Multi-model storage strategies (NoSQL for reads, relational for writes)

**✅ Benefits**

| Pros | Cons |
|------|------|
| Scalability for queries vs writes | Added complexity |
| Independent evolution of models | Eventual consistency (not always ACID) |
| Fits well with message brokers | Requires orchestration & versioning |
| Easier caching / denormalization | Debugging cross-cutting flows |

**🛠 Related Patterns**

- Event Sourcing: Commands produce events, and state is rebuilt from those.
- Saga Pattern: Manages distributed transactions triggered by commands.
- Mediator Pattern (e.g. MediatR): Common CQRS handler orchestration tool.
- Outbox Pattern: Ensures reliable messaging post-command commit.

---

### 🧾 Event Sourcing

Event Sourcing is one of the most powerful and nuanced architectural patterns, especially in the world of distributed systems, audit trails, and reactive architectures. It's a core complement to CQRS and can dramatically reshape how state is managed and replayed.

Instead of persisting current state, Event Sourcing stores a sequence of domain events that represent state transitions. The system’s state is derived by replaying events in order — like reconstructing the full history of every change.

> The truth is in the events — not just the final result.

**🔧 Core Components**

| Element | Role |
|--------|------|
| Event | A fact describing something that happened |
| Aggregate | Rehydrates its state from event history |
| Command Handler | Converts intent into events |
| Event Store | Append-only storage for event streams |
| Projection | Translates events into queryable read models |
| Snapshot (optional) | Caches current state to avoid full replay |

**💡 C# Sketch: Aggregate & Event Store**

```csharp
public abstract class Event { }

public class UserCreated : Event
{
    public string Name { get; }
    public UserCreated(string name) => Name = name;
}

public class UserAggregate
{
    public string Name { get; private set; }

    public void Apply(Event @event)
    {
        switch (@event)
        {
            case UserCreated e:
                Name = e.Name;
                break;
        }
    }

    public IEnumerable<Event> Handle(CreateUserCommand command)
    {
        yield return new UserCreated(command.Name);
    }
}
```

You store `UserCreated` in an append-only store. Rehydration is done by replaying each event through `Apply()`.

**🚀 Real-World Applications**

- Finance: full audit history of transactions
- Logistics / IoT: telemetry streams replayed into new models
- Games: player actions as event logs
- Versioned APIs: replaying domain events under new rules
- Orleans / Kafka: event streams driving actor state or reactive workflows

**✅ Benefits**

| Pros | Cons |
|------|------|
| Auditability (complete history) | Harder to query directly |
| Enables temporal debugging | Event schema evolution required |
| Replays support multiple views | Risk of growing event volumes |
| Event reprocessing for projections | Tooling/debugging needs grow in complexity |

**🛠 Tips for Adoption**

- Use snapshots for long-lived aggregates to avoid replay fatigue.
- Treat events as immutable contracts — version carefully.
- Use projections (or read models) to power UI and analytics.
- Leverage event-driven pub/sub (e.g., Kafka, Orleans streaming) for reactive workflows.
- Validate idempotency if events are reprocessed due to failures.

**🔗 Compared to CQRS Alone**

| Feature | CQRS Only | CQRS + Event Sourcing |
|---------|-----------|----------------------|
| Writes | Direct DB mutations | Events drive state changes |
| Audit Log | Optional | Built-in event history |
| Replay Capability | Limited | Full replay and branching supported |
| Temporal State Views | Complex | Easy — just replay to any timestamp |

---

### 🧭 Mediator Pattern

The Mediator promotes loose coupling by having objects communicate via a mediator object instead of directly. This makes interaction patterns more manageable and refactor-friendly.

> "Talk to the mediator, not each other."

**🔧 Core Structure**

| Component | Role |
|-----------|------|
| Mediator | Orchestrates interactions between components |
| Colleague | Objects that send/receive messages via the mediator |
| Concrete Mediator | Implements coordination logic |
| Message/Event | Optional if using an event-driven variant |

**💡 Classic C# Example (GUI Elements)**

```csharp
public interface IMediator
{
    void Notify(Component sender, string action);
}

public abstract class Component
{
    protected IMediator mediator;
    public Component(IMediator mediator) => this.mediator = mediator;
}

public class Button : Component
{
    public void Click() => mediator.Notify(this, "click");
}

public class TextBox : Component
{
    public void Clear() => Console.WriteLine("TextBox cleared");
}

public class FormMediator : IMediator
{
    private readonly TextBox textBox;

    public FormMediator(TextBox textBox) => this.textBox = textBox;

    public void Notify(Component sender, string action)
    {
        if (sender is Button && action == "click")
            textBox.Clear();
    }
}
```

In this setup, Button doesn't know about TextBox. The FormMediator handles all coordination.

**🚀 Modern Usage: MediatR in ASP.NET Core**
One of the most practical implementations of Mediator today is the MediatR library — heavily used in CQRS, modular handlers, and message pipelines.

```csharp
// Request
public record PingQuery : IRequest<string>;

// Handler
public class PingHandler : IRequestHandler<PingQuery, string>
{
    public Task<string> Handle(PingQuery request, CancellationToken ct) =>
        Task.FromResult("Pong");
}
```

Then inject `IMediator` and call `.Send(new PingQuery())` — decouples request from handling logic.

**✅ Benefits**

| Pros | Cons |
|------|------|
| Decouples inter-object interactions | Mediator can become a bottleneck |
| Centralized communication logic | Potential loss of object autonomy |
| Easier testing & extensibility | One-size-fits-all handler risks |
| Enables loosely coupled CQRS/DDD | Can obscure control flow if overused |

**🧪 Best Practices in Distributed Systems**

- Use mediator to orchestrate command dispatching, not domain logic.
- Keep handler responsibilities focused to avoid God handlers.
- Integrate with pipelines (logging, validation) using MediatR behaviors.
- Consider combining with event buses (e.g. MassTransit, CAP, Orleans Streams) for cross-boundary interactions.

---

### 🧩 Saga Pattern

Saga Pattern is an essential tool when managing distributed transactions across multiple microservices or boundaries without relying on ACID guarantees. It orchestrates long-lived, multi-step workflows while preserving consistency in eventual terms.

A saga breaks a big transaction into a sequence of smaller, independent operations — each with compensating actions in case of failure. Rather than using distributed locks or 2PC (two-phase commit), Sagas rely on coordination and rollback logic.

> “Do Step A, then B, then C — and if B fails, undo A.”

**🔧 Core Components**

| Element | Role |
|--------|------|
| Saga Coordinator | Orchestrates workflow steps or listens to events |
| Saga Step | Local transaction in one service |
| Compensating Action | Undo logic for reversing a previously successful step |
| Event Bus / Command Bus | Transports messages between services |
| State Store | Optional persistence to track saga progression |

**💡 C# Sketch: Order Workflow (Orchestrated)**

```csharp
public interface ISagaStep
{
    Task Execute();
    Task Compensate();
}

public class ReserveInventoryStep : ISagaStep
{
    public async Task Execute() => Console.WriteLine("Reserving inventory...");
    public async Task Compensate() => Console.WriteLine("Releasing inventory...");
}

public class CreateOrderStep : ISagaStep
{
    public async Task Execute() => Console.WriteLine("Creating order...");
    public async Task Compensate() => Console.WriteLine("Cancelling order...");
}

public class OrderSagaCoordinator
{
    private readonly List<ISagaStep> steps = new();

    public void AddStep(ISagaStep step) => steps.Add(step);

    public async Task RunSaga()
    {
        var executedSteps = new Stack<ISagaStep>();

        foreach (var step in steps)
        {
            try
            {
                await step.Execute();
                executedSteps.Push(step);
            }
            catch
            {
                while (executedSteps.Any())
                    await executedSteps.Pop().Compensate();

                throw;
            }
        }
    }
}
```

This handles orchestration with rollback logic — or you could shift to an event choreography model where services react to each other's events autonomously.

**🧪 Choreography vs Orchestration**

| Style | Description | Trade-Offs |
|-------|-------------|------------|
| Orchestrated | Central coordinator drives process | Easy to track; tight control |
| Choreographed | Services react to events from other services | Looser coupling; harder to trace |

**🚀 Real-World Applications**

- Order fulfillment and payment authorization
- Travel booking: flight, hotel, car in separate services
- Resource allocation in cloud provisioning
- Multi-step registration or onboarding
- Fault-tolerant workflows in IoT or sensor systems

**✅ Benefits**

| Pros | Cons |
|------|------|
| Avoids distributed locks | Requires compensating logic |
| Highly scalable | Saga state can become complex |
| Good fit for eventual consistency | Tracing/debugging across services is harder |
| Resilience via rollback logic | Latency may increase in long chains |

**🛠 Tips for Implementation**

- Use Durable Task Framework, MassTransit, or Orleans virtual actors for orchestration.
- Persist saga state for long-lived workflows.
- Always define compensating actions before wiring steps.
- Consider using outbox pattern to ensure message delivery on rollback.
- Integrate with message brokers (e.g. Kafka, RabbitMQ) for choreography.

---

### 🧩 Two-Phase Commit: Overview

The Two-Phase Commit (2PC) protocol is a classic approach to managing distributed transactions with strong consistency guarantees. It’s designed to ensure that all participating systems in a transaction either commit together or roll back together, avoiding data inconsistencies across boundaries.

2PC coordinates a transaction across multiple resource managers (e.g. databases, services) using a central coordinator.

> Think of it like asking: “Are we all ready to commit?” before sealing the deal.

**📊 The Two Phases**

| Phase | Description |
|-------|-------------|
| 1. Prepare | Coordinator sends a PREPARE request to all participants |
|           | Each participant replies READY (if it can commit) or FAIL |
| 2. Commit | If all reply READY, coordinator sends COMMIT; otherwise sends ROLLBACK |

**🔧 Participant States**

- READY: Prepared to commit and has locked resources
- COMMIT: Finalizes changes
- ROLLBACK: Undoes local changes

**💡 Simplified Pseudocode**

```csharp
// Phase 1: Prepare
foreach (participant in participants)
    send PREPARE
    if response != READY
        send ROLLBACK to all
        return

// Phase 2: Commit
foreach (participant in participants)
    send COMMIT
```

**🚀 Use Cases**

- Distributed databases (e.g., XA transactions in relational stores)
- Financial systems requiring strict consistency
- Inter-bank transfers or inventory updates across regions
- Monolithic systems with database shards

**❌ Limitations**

| Challenge | Why It Matters |
|-----------|----------------|
| Blocking | Participants must hold locks during coordination |
| Coordinator is a single point of failure | If it crashes mid-transaction, recovery is hard |
| No tolerance for network partitions | Not ideal for modern distributed/cloud systems |
| Doesn’t scale well | Latency and complexity grow with participant count |

**✅ Modern Alternatives**
Because of its blocking nature and lack of partition tolerance, many modern systems prefer:

- Saga Pattern (eventual consistency + compensating logic)
- Event Sourcing (replayable state transitions)
- Transactional Outbox (reliable messaging post-commit)
- Distributed consensus algorithms (like Raft or Paxos)

**🧠 Practical Insight for Distributed Systems**
In cloud-native design or service mesh architectures, 2PC often falls short. For example:

- In Kubernetes microservices, 2PC’s lock-in is too brittle.
- With systems like Kafka or Orleans, asynchronous event-driven mechanisms are more scalable and resilient.

---

### 📦 Outbox Pattern: Overview

Outbox Pattern is a battle-tested solution for achieving reliable messaging in distributed systems, especially when integrating with message brokers like Kafka, RabbitMQ, or cloud-native queues. It’s designed to solve the dual-write problem, where a service modifies its database and publishes an event — but needs to ensure both happen atomically.

The pattern introduces an "outbox table" within the same database transaction that updates application state. Messages intended for external systems are stored there. A separate process then reads from the outbox table and publishes the messages to the external broker asynchronously, guaranteeing delivery without losing consistency.

> Update your DB + enqueue a message in one transaction — then let a background processor do the rest.

**🛠 Core Flow**

- Service receives a command (e.g. CreateOrder)
- It updates its DB and writes an event record to the Outbox table in the same transaction
- A background publisher (poller, trigger, Debezium, etc.) picks up the event
- The event is published to a message broker
- Once published, the Outbox record is marked as sent or deleted

**💡 C# Sketch**

```csharp
public class OutboxMessage
{
    public Guid Id { get; set; }
    public string Type { get; set; } // e.g., OrderCreated
    public string Payload { get; set; }
    public DateTime OccurredOn { get; set; }
    public bool Sent { get; set; }
}
```

During DB transaction:

```csharp
// 1. Save domain data
dbContext.Orders.Add(order);

// 2. Save outbox message
dbContext.OutboxMessages.Add(new OutboxMessage {
    Type = "OrderCreated",
    Payload = JsonConvert.SerializeObject(order),
    OccurredOn = DateTime.UtcNow
});
```

Then a background service reads unsent messages and publishes them to Kafka or another broker.

**🚀 Real-World Use Cases**

- Order systems: sync with external inventory/payment service
- Event-driven architectures: keep microservices in sync
- Domain-driven design: reliably emit domain events
- Multi-tenant or multi-region systems: coordinate change across boundaries

**✅ Benefits**

| Pros | Cons |
|------|------|
| Guarantees atomicity of state + message | Requires polling or change data capture (CDC) |
| No distributed transaction overhead | Increases infrastructure complexity |
| Decouples publisher from core logic | Needs retry and deduplication safeguards |
| Enables recovery & traceability | Latency between DB write and publish may vary |

**🧪 Implementation Tips**

- Use EF Core interceptors or outbox middleware to hook into DB transaction lifecycle.
- Consider CDC tools like Debezium to stream outbox changes in real-time.
- Use deduplication headers on outbound messages to prevent double processing.
- Store metadata (e.g. tenant ID, correlation ID) in outbox for tracing and filtering.
- Integrate with saga orchestrators or event buses cleanly.

**🔗 Related Patterns**

| Pattern | How It Relates |
|---------|---------------|
| Transactional Outbox | Implements outbox with DB guarantees |
| Inbox Pattern | Used on consumer side to avoid reprocessing |
| Idempotent Receivers | Ensures safe retries |
| Retry/Dead Letter | Handles delivery failures |

---

### 🧪 Dependency Injection: Overview

Dependency Injection (DI) is a foundational principle in maintainable, testable, and flexible architecture. It’s especially important in systems like yours with distributed services, cloud-native components, and tightly scoped configuration boundaries.

DI is a design pattern where dependencies (i.e. services, objects, configs) are provided from the outside rather than being constructed inside a class. This promotes loose coupling, enhances testability, and supports lifecycle control.

> "Don't build the service — ask for it."

**🔧 Common DI Techniques in C#**

| Technique | Description | Example Syntax |
|-----------|-------------|---------------|
| Constructor Injection | Injects via the class constructor | `public MyService(IDep dep)` |
| Property Injection | Sets dependencies through properties | `public IDep Dep { get; set; }` |
| Method Injection | Passes dependency as method parameter | `DoWork(IDep dep)` |
| Service Provider Lookup | Manual resolution using IServiceProvider | `sp.GetService<IDep>()` |

Constructor injection is the most idiomatic and preferred in .NET.

**🚀 ASP.NET Core Example (Built-in DI Container)**

```csharp
// Registration
services.AddScoped<IRepository, SqlRepository>();
services.AddSingleton<ILogger, ConsoleLogger>();

// Consumption
public class OrderService
{
    private readonly IRepository repo;
    public OrderService(IRepository repo) => this.repo = repo;

    public void ProcessOrder() => repo.Save();
}
```
The framework resolves `IRepository` automatically — no need to wire manually.

**✅ Benefits**

| Pros | Cons |
|------|------|
| Promotes testability and mocking | Learning curve for lifetimes |
| Encourages modular architecture | Misconfigured lifetimes cause issues |
| Centralized service management | Service registration can grow complex |
| Enables config-driven or runtime injection | Can obscure control flow |

**🧠 Lifetime Management**

| Lifetime | Description | Use When… |
|----------|-------------|-----------|
| Singleton | One instance for entire app lifecycle | Stateless, shared, cached services |
| Scoped | One per request scope (e.g., web request) | Request-specific logic (e.g., user context) |
| Transient | New instance on every injection | Lightweight, stateless, non-cached objects |

Be careful with injecting scoped services into singletons — it can cause runtime errors.

**🛠 In Distributed Systems (Your Space)**

- Per-tenant configurations: Use DI to inject tenant-aware services dynamically.
- Feature toggles: Swap service implementations conditionally with DI factories.
- Secure secrets/config maps: In Kubernetes, inject secrets into services using DI wrappers around IOptions or custom providers.
- Pluggable transports: Swap Orleans, Kafka, or HTTP clients using DI and strategies.

**🔗 Related Patterns**

| Pattern | How It Interacts |
|---------|------------------|
| Service Locator | Anti-pattern when overused — hides dependencies |
| Factory Pattern | DI may delegate instantiation to factories |
| Decorator | Inject decorators to extend service behavior |
| Builder | Wrap DI logic for complex configuration trees |

---

### 🔍 Service Locator Pattern: Overview

The Service Locator acts as a registry that knows how to provide instances of services on request. Instead of injecting dependencies, classes call the locator directly to retrieve what they need.

> “Tell me where the service is — and I’ll go get it myself.”

**💡 Basic C# Example**

```csharp
public interface IService { void Execute(); }

public class MyService : IService
{
    public void Execute() => Console.WriteLine("Running service logic...");
}

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> services = new();

    public static void Register<T>(T implementation) =>
        services[typeof(T)] = implementation;

    public static T Resolve<T>() => (T)services[typeof(T)];
}
```

Usage:

```csharp
ServiceLocator.Register<IService>(new MyService());
var svc = ServiceLocator.Resolve<IService>();
svc.Execute();
```

**🛠 Use Cases**

- Legacy systems without DI containers
- Dynamically pluggable modules
- Systems with runtime-resolved dependencies (e.g., rule engines or plugin loaders)
- Bridging old APIs where constructor injection isn’t feasible

**🧪 Pros vs Cons**

| ✅ Pros | ⚠️ Cons |
|---------|---------|
| Centralized registration | Hides dependencies — violates explicit design |
| Useful in bootstrapping or edge scenarios | Harder to unit test — encourages global state |
| Dynamic resolution in plugin architectures | Encourages service lookup over constructor contracts |
| Can simulate DI where DI frameworks are unavailable | Can lead to tight coupling and brittle code |

**🆚 DI vs Service Locator**

| Pattern | Behavior | Design Implications |
|---------|----------|--------------------|
| Dependency Injection | Dependencies provided externally via constructor | Promotes transparency and testability |
| Service Locator | Dependencies retrieved internally from registry | Obscures control flow and dependencies |

In short: DI makes dependencies visible, while Service Locator makes them implicit.

**🧠 When It Makes Sense**

- In game engines, where object graphs are hard-coded and lifecycle is custom
- In scripting environments, where resolution is dynamic
- In framework bootstrapping layers, before full DI is ready
- In plugin-driven extensibility, where registration and lookup are runtime concerns

**🔧 Refactoring Tips**

- Replace service locator calls with constructor injection where feasible
- Use factory or provider interfaces if dependencies need runtime control
- In ASP.NET Core, switch from custom locator to built-in IServiceProvider, and hide resolution logic behind adapter classes or middleware

---

### 🧯 Circuit Breaker Pattern

The Circuit Breaker prevents an application from repeatedly trying to execute an operation that's likely to fail — say, calling an overloaded downstream service or unstable API.

Like an electric fuse: when too many errors occur, it “breaks” the circuit to stop damage — then retries later.

**🚦 States of a Circuit Breaker**

| State | Description |
|-------|-------------|
| Closed | Requests flow normally. Failures are tracked |
| Open | Requests are blocked immediately — fallback logic or error returned |
| Half-Open | Some requests allowed to test if recovery is possible |
| Reset | On success threshold, breaker closes and normal traffic resumes |

**💡 C# Example: Polly Integration**

```csharp
var circuitBreakerPolicy = Policy
    .Handle<Exception>()
    .CircuitBreakerAsync(
        exceptionsAllowedBeforeBreaking: 3,
        durationOfBreak: TimeSpan.FromSeconds(30)
    );

await circuitBreakerPolicy.ExecuteAsync(() => service.CallExternalApiAsync());
```

You can chain this with retry, timeout, or fallback policies for a layered defense.

**🚀 Real-World Use Cases**

- API gateways and aggregators
- Microservices calling flaky downstream dependencies
- Streaming systems or actor models (e.g., Orleans) where remote grains may crash
- Telemetry ingestion platforms throttling bad endpoints

**✅ Benefits**

| Advantage | Impact |
|-----------|--------|
| Prevents system overload | Avoids cascading failure |
| Supports graceful degradation | Improves user experience during outages |
| Enables auto-recovery | No manual intervention to resume operations |
| Reduces wasted resources | Blocks futile retries and connection attempts |

**⚠️ Risks & Mitigations**

| Concern | Strategy |
|---------|----------|
| Overly sensitive breaker triggers | Fine-tune failure threshold, test in staging |
| Recovery delay too short or long | Use telemetry-based tuning |
| Hidden fallback failures | Log aggressively and monitor fallback health |

**🔗 Integration with Other Patterns**

| Pattern | Role in Resilience Stack |
|---------|-------------------------|
| Retry Pattern | Works alongside breaker in failure recovery |
| Timeout Pattern | Times out stuck operations before breaker triggers |
| Bulkhead Pattern | Isolates failure domains |
| Fallback Pattern | Provides alternative logic on failure |

---

### 🔁 Retry Pattern

Retry is a pattern where failed operations are automatically retried a limited number of times — typically because the failure is expected to be temporary (e.g., timeouts, rate limits, transient network drops).

> "Try again… but smartly."

**🧠 Core Concepts**

| Concept | Why It Matters |
|---------|---------------|
| Transient Errors | Failure that may succeed if retried (e.g., 503, timeout) |
| Backoff Strategy | Prevent hammering the failing resource |
| Retry Limit | Avoid infinite loops |
| Idempotency | Safe to retry without side effects |
| Jitter | Avoid retry storms across many clients |

**💡 C# Example using Polly**

```csharp
var retryPolicy = Policy
    .Handle<HttpRequestException>()
    .WaitAndRetryAsync(
        retryCount: 3,
        sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
        onRetry: (exception, timeSpan, context) =>
        {
            Console.WriteLine($"Retrying after {timeSpan.TotalSeconds}s due to: {exception.Message}");
        });

await retryPolicy.ExecuteAsync(() => SendHttpRequestAsync());
```

- Implements exponential backoff
- Optional jitter can randomize retry intervals to avoid stampedes
- Pluggable with timeout, circuit breaker, fallback strategies

**🚀 Real-World Use Cases**

- Cloud SDK calls (e.g. AWS throttling)
- Database or cache access during failover
- HTTP/gRPC service calls in microservices
- Message broker (Kafka/Orleans) retry for at-least-once delivery

**✅ Pros**

| Benefit | Why It Helps |
|---------|--------------|
| Handles temporary failures | Improves success rate of operations |
| Reduces need for manual intervention | Keeps services running smoothly |
| Works well with distributed timeouts | Bridges flaky upstream calls |

**⚠️ Risks & Mitigation**

| Risk | Strategy |
|------|---------|
| Repeated side effects | Ensure idempotency and safe retries |
| Overload on downstream services | Use exponential backoff + jitter |
| Retry storms across services | Use circuit breakers or retry caps |
| Masked systemic failures | Log and monitor retry behavior |

**🔗 Related Patterns**

| Pattern | How It Interacts |
|---------|------------------|
| Circuit Breaker | Prevents retrying when failures persist |
| Timeout | Defines retry thresholds |
| Bulkhead | Limits concurrency to prevent overload |
| Fallback | Provides alternative when retries fail |
| Outbox | Ensures reliable retry in message delivery |

**🧪 Best Practices for Distributed Systems**

- Use decorated pipelines (e.g. Polly + MediatR behaviors)
- Log retry attempts and their reasons — valuable for tracing
- Separate retry logic from business logic for clarity and testability
- Apply retry selectively — not everything should be retried!

---

### 🧱 Bulkhead Pattern: Overview

The idea is to partition resources — threads, memory, connections — so failures in one partition don’t affect others. Each partition handles a specific type of workload or caller, and if it's overwhelmed, it fails gracefully without impacting other flows.

> “A failure in one section doesn't mean total collapse.”

**🛠 Core Implementation Concepts**

| Partitioned By | Example Use Case |
|----------------|------------------|
| Thread pools | Separate executor pools for IO vs CPU-bound tasks |
| Rate limiting buckets | VIP vs standard clients |
| Service instances | Dedicated pods for critical vs non-critical APIs |
| Queue separation | Isolated queues for high-priority jobs |
| Connection pools | Different pool sizes for external vs internal calls |

**💡 .NET Example Using Polly**

```csharp
var bulkheadPolicy = Policy.BulkheadAsync(
    maxParallelization: 5,
    maxQueuingActions: 10,
    onBulkheadRejectedAsync: context =>
    {
        Console.WriteLine("Bulkhead rejected request.");
        return Task.CompletedTask;
    });

await bulkheadPolicy.ExecuteAsync(() => SomeCriticalCallAsync());
```

This creates a virtual gate: only 5 operations allowed concurrently, with 10 queued; the rest are rejected instantly.

**🚀 Real-World Applications**

- Kubernetes workloads: Use CPU/memory quotas and separate deployments for risky services
- Orleans grains: Prioritize scheduling for system grains vs user grains
- Kafka consumers: Assign critical partitions to dedicated consumer groups
- API gateways: Route admin traffic differently from general user requests
- Telemetry pipelines: Isolate high-throughput ingestion from analytics processors

**✅ Benefits**

| Strengths | Why It Matters |
|-----------|---------------|
| Isolates faults | Prevents one failing component from dragging down others |
| Protects critical paths | Ensures VIP or system traffic always gets through |
| Improves resilience under stress | Limits cascading failures in overload scenarios |
| Allows graceful degradation | Service partially functions vs total outage |

**⚠️ Risks and Mitigation**

| Challenge | Strategy |
|-----------|---------|
| Tuning limits incorrectly | Use telemetry and load testing |
| Complex configuration | Abstract with DI, templates, or middlewares |
| Uneven resource utilization | Monitor saturation across partitions |
| Starvation in low-priority zones | Implement adaptive quotas |

**🔗 Related Patterns**

| Pattern | Role in Resilience Strategy |
|---------|----------------------------|
| Retry & Circuit Breaker | Retry safely within a bulkhead zone |
| Rate Limiter | Controls request flow into bulkhead boundaries |
| Timeout | Prevents stalled tasks from clogging bulkhead |
| Fallback | Serves degraded response if bulkhead is closed |

---

### 📶 Rate Limiter Pattern

**Throttle incoming requests to prevent overload**

**🔧 Purpose**
Limit the rate of incoming traffic to protect system capacity, ensure fairness, and avoid brute-force denial-of-service risks.

**💡 Techniques**

| Strategy | Description |
|----------|-------------|
| Fixed Window | Allow N requests per time window (e.g. 10/sec) |
| Sliding Window | Smoother rate enforcement via rolling window |
| Token Bucket | Accumulate tokens and consume them per request |
| Leaky Bucket | Ensure outflow at steady rate despite bursts |

**💡 ASP.NET Core Middleware Example**

```csharp
app.UseRateLimiter(new RateLimiterOptions
{
    GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
        RateLimitPartition.GetFixedWindowLimiter("global", _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 100,
            Window = TimeSpan.FromSeconds(1),
            QueueLimit = 10,
            QueueProcessingOrder = QueueProcessingOrder.OldestFirst
        }))
});
```

Or leverage third-party libraries like AspNetCoreRateLimit or traffic control via API Gateway (e.g., Kong, Envoy, Azure APIM).

**🚀 Use Cases**

- Protect slow downstream dependencies
- Enforce fairness across multi-tenant APIs
- Prevent brute-force and scraping attacks
- Throttle telemetry bursts from edge devices

**✅ Pros & Cons**

| ✅ Advantages | ⚠️ Trade-Offs |
|--------------|--------------|
| Controls load during traffic spikes | Can introduce rejection or latency |
| Supports predictable resource use | Misconfigured limits frustrate users/devices |
| Enables fairness across callers | Requires coordination in distributed setups |

**🧠 Bulkhead vs Rate Limiting — Strategic Comparison**

| Feature | Bulkhead | Rate Limiting |
|---------|----------|--------------|
| Goal | Isolate resource usage | Control traffic volume |
| Operates On | Threads, memory, CPU, IO | Requests, messages, or calls |
| Fails With | Rejection, queue overflow | Throttling, HTTP 429, delayed retry |
| Best Fit | Internal execution management | External interaction control |

**🔗 Integration Tips**

- Chain Rate Limiting → Bulkhead → Retry → Circuit Breaker for maximum resilience
- Monitor queue depth and rejections for early overload signals
- Use Partitioned Rate Limiting to throttle by user, IP, tenant, or region
- In Orleans, consider limiting grain activation per silo with bulkheads and throttle external calls into grain clusters

---

### 🧭 Ambassador Pattern

An ambassador acts as a local service that manages outbound communication from an application to a remote system. It can handle retry, timeout, circuit breaker, authentication, protocol bridging, or even rate limiting — allowing the main app to stay focused and clean.

> "The ambassador speaks on behalf of your service — elegantly and robustly."

**🔧 Architecture Components**

| Component | Role |
|-----------|------|
| Main Service | Business logic, unaware of outbound orchestration complexity |
| Ambassador Service / Sidecar | Handles outbound traffic, encapsulates infrastructure concerns |
| Remote Endpoint | Target system — could be API, message broker, DB, etc |
| Configuration Plane | Adjusts ambassador behavior based on policy |

This pattern often leverages sidecars in Kubernetes, such as Envoy, Linkerd, or custom-built proxies for edge calls.

**💡 Use Cases**

- Service Mesh Outbound Routing: Ambassador sidecar manages TLS termination, retries, and mTLS authentication.
- Legacy System Bridging: Ambassador translates gRPC to SOAP or REST, shielding modern apps from legacy complexity.
- Observability Injection: Ambassador logs every outbound request and exports metrics/timing to Prometheus.
- Multi-Tenant Routing: Ambassador injects tenant context and routes to tenant-specific upstreams.
- Kubernetes Telemetry Gateways: A pod's sidecar ambassador pre-processes sensor data before forwarding.

**💻 Simplified .NET Illustration**

```csharp
public class BillingAmbassador
{
    private readonly HttpClient client;
    public BillingAmbassador(HttpClient client) => this.client = client;

    public async Task<Invoice> CreateInvoiceAsync(Order order)
    {
        try
        {
            return await client.PostAsJsonAsync("/billing", order);
        }
        catch (Exception ex)
        {
            // Retry, fallback, circuit breaker logic here
            Console.WriteLine($"Ambassador failed: {ex.Message}");
            throw;
        }
    }
}
```

Instead of scattering retry and telemetry logic across the codebase, your app calls the ambassador, which handles resiliency and communication details.

**✅ Benefits**

| Pros | Trade-Offs |
|------|------------|
| Decouples infrastructure from business logic | Adds one more hop/layer to debug |
| Centralizes reliability concerns | Can duplicate logic across ambassadors |
| Enables protocol abstraction | Version management needs clear boundaries |
| Simplifies service code | Ambassador must stay in sync with upstream APIs |

**🔗 Related Patterns**

| Pattern | Synergy With Ambassador |
|---------|------------------------|
| Sidecar | Ambassador often deployed as a sidecar container |
| Proxy | Ambassador may proxy traffic with enhanced features |
| Façade | Can serve as external façade to upstream service |
| Circuit Breaker / Retry / Timeout | Often embedded in ambassador logic |
| Strangler Fig | Ambassador can route legacy traffic to new systems |

**🛠 Tools & Frameworks**

| Tool | Use Case |
|------|----------|
| Envoy Proxy | Sidecar ambassador in service mesh |
| Linkerd | Lightweight mTLS, retry, timeout ambassador logic |
| Polly + HttpClientFactory | Build ambassador-style clients in .NET |
| API Gateways (Kong, APIM) | External ambassadors for legacy or multi-tenant APIs |

---

### 🧭 BFF Pattern

A BFF is a custom backend service tailored for a specific frontend interface — it aggregates, transforms, filters, and sometimes enriches data from multiple microservices before delivering it to the frontend. This avoids frontend-overfetching and keeps business logic out of the UI layer.

> “Each frontend deserves its own backend concierge.”

**💡 Example Scenario**
Imagine a microservices ecosystem with:

- UserService, OrderService, InventoryService

For your web app, you build a BFF that:

- Fetches user profile
- Aggregates recent orders
- Enriches order data with inventory status
- Formats it into a single, lightweight payload

For your mobile app, you build a separate BFF:

- Returns minimal order data
- Fetches alerts and push notification configs

Each BFF calls the same downstream services, but tailors responses to the consuming UI.

**🔧 .NET Sketch: Web BFF**

```csharp
public class WebBffController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IOrderService orderService;
    private readonly IInventoryService inventoryService;

    public async Task<ActionResult<UserDashboardDto>> GetDashboard(Guid userId)
    {
        var user = await userService.GetUser(userId);
        var orders = await orderService.GetOrdersForUser(userId);
        var enrichedOrders = await EnrichOrdersWithInventory(orders);
        return Ok(new UserDashboardDto(user, enrichedOrders));
    }
}
```

**✅ Benefits**

| Advantage | Trade-Off |
|-----------|-----------|
| UI-specific optimization | Increased backend duplication |
| Separation of concerns | Adds coordination layer |
| Easier caching and shaping | Requires governance across BFFs |
| Hides microservice complexity | BFF becomes bottleneck if not scaled |

**🚀 Real-World Applications**

- Mobile apps: Avoid over-fetching, battery drain, and UI-side aggregation
- SPAs / Dashboards: Pre-shaped data for real-time UIs
- Multitenant platforms: Tenant-specific formatting or rules
- Feature toggling: Inject flags or A/B logic server-side

**🔗 Related Patterns**

| Pattern | Connection |
|--------|------------|
| API Gateway | Gateway may delegate to BFFs based on route/interface |
| Facade | BFF acts as a façade over microservice mesh |
| Adapter | Transforms protocol/data for UI consumption |
| Anti-Corruption Layer | BFF insulates frontend from domain entanglement |
| Strangler Fig | BFFs can gradually replace monolith endpoints |

**🧠 Tips for Scaling BFFs**

- Use DI for clear composition of services and logic
- Add caching with headers for performance-critical flows
- Log and trace across service boundaries (OpenTelemetry, App Insights)
- Use versioning or x-client-type headers to support multiple frontends cleanly
- Consider BFF-as-a-function via serverless for simple view-specific logic

---

### ⚡ Reactive Streams

Reactive Streams define a standard for asynchronous stream processing with non-blocking backpressure — so producers and consumers can communicate at the right pace. The protocol ensures that fast producers won’t overwhelm slow consumers.

> “Push when you can, pull when you must — flow control is the heart of resilience.”

**🧠 Core Principles (Defined by Reactive Streams Specification)**

| Principle | Description |
|-----------|-------------|
| Asynchronous | Producers and consumers operate independently |
| Non-blocking | No thread blocking — great for scalability |
| Backpressure | Consumers signal how much they can handle |
| Stream of elements | Ordered data transmission — potentially infinite |
| Interfaces | Publisher, Subscriber, Subscription, Processor |

**💡 Interfaces in Reactive Streams API (Java / .NET Concepts)**

```csharp
interface IPublisher<T>
{
    void Subscribe(ISubscriber<T> subscriber);
}

interface ISubscriber<T>
{
    void OnSubscribe(ISubscription subscription);
    void OnNext(T item);
    void OnError(Exception e);
    void OnComplete();
}

interface ISubscription
{
    void Request(long n);   // Backpressure control
    void Cancel();          // Stop stream
}
```

These form the contract for any reactive-capable system — such as those built with Rx.NET, Project Reactor (Java), or Akka Streams.

**🚀 Real-World Use Cases in Distributed Systems**

- Telemetry ingestion: Stream data with backpressure to avoid buffer overflows
- Kafka streams: Wrap consumers as reactive publishers for enriched flows
- Orleans grains: Use reactive observers for stream composition across silos
- Mobile/web dashboards: Reactive APIs push updates to live UIs (SignalR, WebSockets)
- Event sourcing pipelines: Project domain events into dynamic read models

**🔄 How It Compares**

| Feature | Reactive Streams | Traditional Observables |
|---------|------------------|------------------------|
| Backpressure support | ✅ Built-in | ❌ Often missing |
| Thread management | Non-blocking | Can be blocking or hybrid |
| Flow control granularity | Per-subscription | Global or hardcoded |
| System compatibility | Kafka, gRPC, WebFlux | Limited by adapter logic |

**🔗 Key Libraries and Tools**

| Platform | Reactive Tool |
|----------|--------------|
| .NET | Rx.NET, System.Threading.Channels |
| Java | Project Reactor, Akka Streams |
| JavaScript | RxJS |
| Kotlin | Kotlin Flow |
| Spring | WebFlux (Reactor-based) |
| Kafka Streams | Custom wrappers or Akka integration |

**🛠 Tips for Implementation**

- Batch or buffer items when downstream pressure increases
- Apply debounce, throttle, groupBy, and flatMap to shape your stream
- Integrate with Circuit Breakers or Bulkheads to manage resource saturation
- Monitor consumer lag and publisher overflow using metrics (Prometheus, OpenTelemetry)

---

### 🎭 Actor Model

The Actor Model is a computational paradigm where "actors" are the universal primitive of computation. Each actor is an independent unit that:

- Has its own state
- Processes messages asynchronously
- Can:
  - Send messages to other actors
  - Create new actors
  - Change its own internal state

Actors do not share memory and communicate exclusively via message passing — which makes them perfect for modeling isolated, resilient systems.

> “Actors don’t share — they talk.”

**🧠 Core Principles**

| Principle | Description |
|-----------|-------------|
| Encapsulation | Actor state is private and isolated |
| Concurrency | Each actor can execute concurrently without locks |
| Location Transparency | Actors talk via identifiers, not physical locations |
| Supervision | Parent actors monitor and restart child actors on failure |

**💡 Orleans Example**

```csharp
public interface IDeviceGrain : IGrainWithStringKey
{
    Task ProcessTelemetry(SensorData data);
}

public class DeviceGrain : Grain, IDeviceGrain
{
    private int alertCount = 0;

    public Task ProcessTelemetry(SensorData data)
    {
        if (data.Temperature > 100)
            alertCount++;

        return Task.CompletedTask;
    }
}
```

Each DeviceGrain represents a uniquely addressable actor — managing its own state and lifecycle independently.

**🚀 Real-World Applications**

- IoT telemetry: Each device as an actor processing live data
- Online gaming: Player sessions modeled as actors with persistent state
- Workflow engines: Step-by-step processing modeled via actor transitions
- Streaming ingestion: Partitioned processors in event pipelines
- Multi-tenant compute: Each tenant or domain encapsulated in actor boundaries

**✅ Benefits**

| Advantage | Impact |
|-----------|--------|
| Scalable concurrency | Massive actor count, distributed activation |
| Fault tolerance via supervision | Fail and recover independently |
| Natural fit for cloud/distributed | Works well with dynamic hosting and locality |
| Easy parallelism | No locking, no race conditions |

**⚠️ Trade-Offs**

| Concern | Mitigation |
|---------|-----------|
| Overhead of actor creation | Use actor pools or lazy activation |
| State persistence complexity | Use grain state + storage providers in Orleans |
| Distributed messaging latency | Optimize placement and locality |
| Debugging async message flow | Use correlation IDs and tracing (OpenTelemetry!) |

**🔗 Related Concepts**

| Pattern / Model | Relationship |
|-----------------|-------------|
| Reactive Streams | Actor pipelines can use backpressure-aware messaging |
| CQRS + Event Sourcing | Actors emit events and rebuild state from event history |
| Saga Pattern | Actor chains represent distributed transaction flows |
| State Machine | Actor lifecycle tied to internal state transitions |
| Sidecar Pattern | Actors can use sidecars for telemetry, authentication, etc |

**🛠 Tools & Frameworks**

| Platform | Actor Framework |
|----------|----------------|
| .NET | Orleans |
| JVM | Akka, Scala Actors |
| Rust | Actix |
| Erlang | Built-in actor model (gen_server) |
| Azure | Durable Entities via Durable Functions |

---

### 🌪️ Fan-Out & Fan-In Pattern

**🔁 Fan-Out**  
Distributes a single event or request to multiple downstream consumers or services.  
"One request, many processors."

**🔄 Fan-In**  
Collects multiple responses or events back into a single result, state, or triggering action.  
"Many responses, one aggregation."

**💡 Example: Telemetry Pipeline**

- A sensor emits a signal → Fan-out → processing, alerting, enrichment services.
- Outputs from enrichment + alerting → Fan-in → consolidated dashboard or alert payload.

You might fan out using a topic/queue, then fan in via aggregator service, workflow engine, or stateful actor (e.g., Orleans grain).

**📬 Message Broker Topologies**

| Topology Type | Characteristics | Best For |
|---------------|----------------|----------|
| Publish/Subscribe | One-to-many distribution via topics | Broadcast, multi-consumer workflows |
| Queue/Work Queue | Point-to-point, load-balanced consumption | Job processing, distributed tasks |
| Routing (Topic Exchange) | Messages sent based on routing keys | Pattern-matched consumers |
| Headers Exchange | Custom rules based on headers | Complex routing logic |
| Partitioned Streams | Kafka-style topic partitions | High-throughput, ordered, parallel processing |
| Dead Letter Queues | Stores failed messages for later inspection | Retry strategies, error analysis |

**🚀 Real-World Fan-Out/Fan-In Use Cases**

- Cloud provisioning workflows: Fan-out to DNS, auth, billing; fan-in to confirm resource status.
- Orleans grains: Fan-out from orchestrator grain; each worker grain returns partial result → fan-in.
- Kafka streams: Partitioned fan-out for parallel enrichment → fan-in using windowed aggregators.
- Telemetry pipelines: Sensor signal → fan-out to logging, alerting, and ML services → fan-in for unified dashboard.
- Data lake ingestion: Fan-out to pre-processors → fan-in for schema harmonization or validation.

**🧠 Pattern Trade-Offs**

| Fan-Out Advantages | Fan-In Challenges |
|--------------------|------------------|
| Parallel processing, increased throughput | Requires stateful coordination (e.g., correlation IDs) |
| Decouples producer from consumers | Ordering and aggregation latency |
| Easy to scale consumers independently | Retry and failure handling can get complex |

**🛠 Architectural Tips**

- Use correlation IDs to stitch results back together during fan-in
- Track message flow using distributed tracing (e.g., OpenTelemetry)
- Consider eventual consistency where tight orchestration isn't needed
- In Orleans, use virtual actors for stateful aggregation during fan-in
- In Kafka, apply stream joins and windowed aggregations for clean reassembly

---

### 🧭 DDD: Core Philosophy

DDD promotes building software by understanding and modeling the domain, not just slinging CRUD endpoints. It aims for expressive, decoupled, and maintainable architecture via strategic and tactical patterns.

> “If you can't talk to the business in terms of your code, you're missing the point.”

**🧠 Strategic Design Concepts**

| Concept | Description |
|---------|-------------|
| Bounded Context | A logical boundary where a model applies consistently |
| Ubiquitous Language | Shared terminology used by both developers and domain experts |
| Context Mapping | Defines relationships and integrations between bounded contexts |
| Core Domain | The most valuable domain logic that deserves deep modeling |
| Supporting/Subdomains | Areas of lesser strategic importance — may be handled with CRUD or off-the-shelf tools |

These boundaries allow for team autonomy, model clarity, and enable modular evolution — especially in microservices and multi-tenant systems.

**🛠 Tactical Design Patterns**

| Pattern | Role in Domain Modeling |
|---------|------------------------|
| Entity | Objects with identity and lifecycle (e.g. User, Order) |
| Value Object | Objects defined by attributes, not identity (e.g. Address, DateRange) |
| Aggregate | Cluster of entities/value objects treated as a transaction boundary |
| Repository | Interface for loading/storing aggregates |
| Domain Event | Captures something significant that happened (used for pub/sub, event sourcing) |
| Service | Stateless operations that don’t belong to an entity or value object |
| Factory | Encapsulates complex aggregate creation logic |

**💡 C# Sketch: Aggregate & Domain Event**

```csharp
public class Order
{
    public Guid Id { get; private set; }
    public List<OrderItem> Items { get; private set; }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
        DomainEvents.Raise(new ItemAddedToOrderEvent(item));
    }
}
```

DDD modeling encourages behavior inside domain objects — not anemic DTO-style logic.

**🧪 Patterns in Practice**

- CQRS: DDD complements CQRS by separating the write-rich domain model from read models
- Event Sourcing: Domain events as the source of truth for replaying state
- Saga Pattern: Represents long-running domain workflows across aggregates
- Orleans: Actors can represent aggregates with lifecycle and locality

**🚀 Benefits**

| Advantage | Why It Matters |
|-----------|---------------|
| Deep domain alignment | Code reflects business logic accurately |
| Improved communication | Devs & domain experts speak the same language |
| Modularity through bounded contexts | Enables microservice decomposition |
| Evolvability | Domains can change without breaking the whole system |

**⚠️ Common Missteps**

| Pitfall | Solution |
|--------|---------|
| Overengineering trivial domains | Apply DDD where complexity warrants it |
| Ignoring Ubiquitous Language | Involve domain experts from the start |
| Entity-Only thinking | Model with value objects, aggregates, and events |
| Inconsistent boundaries | Use context mapping to formalize relationships |

**📦 Tooling & Ecosystem**

| Stack | Recommendation |
|-------|---------------|
| .NET | Clean Architecture, MediatR, EventStoreDB, EF Core |
| Framework | Use modules for each bounded context |
| Testing | Write specifications around domain behavior — not just data

---
