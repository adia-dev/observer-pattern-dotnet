using ObserverPattern.Kafka;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("mini-kafka started.");

        KafkaStream stream = new KafkaStream();
        Kafka kafka = new Kafka(stream);
        KafkaProducer producer = new KafkaProducer(kafka);

        string[] topics =
            new string[] { "code.execution.request", "code.execution.result",
                       "code.execution.status" };

        List<KafkaConsumer> consumers = new List<KafkaConsumer>();
        Random rnd = new Random();
        for (int i = 0; i < 5; ++i)
        {
            int randomTopicIndex = rnd.Next(0, topics.Length);

            KafkaConsumer consumer = new KafkaConsumer(topics[randomTopicIndex]);
            stream.Subscribe(topics[randomTopicIndex], consumer);

            consumers.Add(consumer);
        }

        var cancellationTokenSource = new CancellationTokenSource();
        var produceTask = ProduceMessagesPeriodically(
            producer, topics, cancellationTokenSource.Token);

        Console.WriteLine("Press any key to stop producing messages...");
        Console.ReadKey();

        cancellationTokenSource.Cancel();
        await produceTask;

        Console.WriteLine("Stopped producing messages.");
    }

    private static async
        Task ProduceMessagesPeriodically(KafkaProducer producer, string[] topics,
                                         CancellationToken cancellationToken)
    {
        Random rnd = new Random();
        while (!cancellationToken.IsCancellationRequested)
        {
            int randomTopicIndex = rnd.Next(0, topics.Length);
            string topic = topics[randomTopicIndex];
            string message = $"Message at {DateTime.Now}";

            producer.Produce(topic, message);
            Console.WriteLine($"Produced message: {message} to topic: {topic}");

            int delay = rnd.Next(500, 2000);
            await Task.Delay(delay, cancellationToken);
        }
    }
}
