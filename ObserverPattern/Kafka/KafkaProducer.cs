namespace ObserverPattern.Kafka;

public class KafkaProducer
{
    private readonly Kafka _kafka;

    public KafkaProducer(Kafka kafka) { _kafka = kafka; }

    public void Produce(string topic, string message)
    {
        _kafka.AddMessage(topic, message);
    }
}
