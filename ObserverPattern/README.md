# Mini Kafka - Observer Pattern Example

This project is a simple implementation of a mini Kafka system to learn about the Observer pattern in C#. It demonstrates how publishers (producers) and subscribers (consumers) can communicate using the observer pattern.

## Project Structure

- **AbstractNotifier.cs**: Defines an abstract class that manages topic-based subscriptions and notifications.
- **KafkaProducer.cs**: Represents a producer that adds messages to topics in Kafka.
- **Kafka.cs**: Manages the storage of messages and notifies subscribers when new messages are added.
- **Program.cs**: The main entry point that sets up the Kafka system, creates consumers, and produces messages periodically.
- **KafkaStream.cs**: Implements the notification mechanism for subscribers based on topics.
- **KafkaConsumer.cs**: Represents a consumer that receives messages for a specific topic.
- **ISubscriber.cs**: An interface that defines the update method for subscribers.

## How It Works

1. **Publisher/Subscriber Management**:
   - `AbstractNotifier` manages subscribers based on topics. It provides methods to subscribe, unsubscribe, and notify subscribers.

2. **Producing Messages**:
   - `KafkaProducer` adds messages to topics in the `Kafka` class.
   - `Kafka` stores messages and notifies the relevant subscribers when a new message is added to a topic.

3. **Consuming Messages**:
   - `KafkaConsumer` implements the `ISubscriber` interface and receives updates when new messages are available for its subscribed topic.

4. **Periodic Message Production**:
   - `Program.cs` simulates message production at random intervals. It sets up the Kafka system, subscribes consumers to topics, and produces messages periodically until a key is pressed to stop.

## Running the Project

1. Clone the repository.
2. Open the project in your preferred IDE.
3. Build and run the project.

```bash
dotnet run
```

4. The program will start producing messages at random intervals. Press any key to stop the production of messages.

## Example Output

```
mini-kafka started.
Produced message: Message at 6/19/2024 10:24:25 AM to topic: code.execution.request
Message received on consumer 123e4567-e89b-12d3-a456-426614174000 for topic code.execution.request
...
Press any key to stop producing messages...
Stopped producing messages.
```

## Learning Objectives

This project aims to help you understand the following concepts:

- **Observer Pattern**: Learn how to implement the observer pattern to manage publishers and subscribers.
- **Topic-Based Subscription**: Understand how to manage subscriptions based on topics.
- **Asynchronous Programming**: Get hands-on experience with asynchronous programming using `Task` and `CancellationToken`.

## Future Improvements (will probably never happen)

- **Thread Safety**: Implement thread-safe collections or locking mechanisms to handle concurrent access.
- **Error Handling**: Add proper error handling throughout the code.
- **Logging**: Integrate a logging framework to provide more detailed logs.
