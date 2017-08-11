using UnityEngine;

public class StartupBinder : ButtBehaviour {

	[SerializeField, AsInterface(typeof(IProducer<CombatCommand>))]
	private ButtBehaviour m_Producer;

	[SerializeField, AsInterface(typeof(ICombatController))]
	private ButtBehaviour m_Controller;


	private IProducer<CombatCommand> m_CombatProducer = null;
	private ICombatController m_CombatController = null;

	protected override void Awake() {

		m_CombatProducer = TypeUtilities.Cast<IProducer<CombatCommand>>(m_Producer);
		m_CombatController = TypeUtilities.Cast<ICombatController>(m_Controller);
	}

	protected override void OnEnable() {

		m_CombatProducer.BindConsumer(m_CombatController.ReceiveCommand);
	}

	protected override void OnDisable() {

		m_CombatProducer.UnbindConsumer(m_CombatController.ReceiveCommand);
	}
}
