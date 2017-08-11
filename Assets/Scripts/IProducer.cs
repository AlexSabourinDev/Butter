
public delegate void ConsumerDelegate<Type>(Type command);

// Bind a consumer to the producer, allowing the producer to notify the consumers
// of a new item.
public interface IProducer<Type> {

	ConsumerDelegate<Type> Consumers { get; }

	void BindConsumer(ConsumerDelegate<Type> consumer);
	void UnbindConsumer(ConsumerDelegate<Type> consumer);
}