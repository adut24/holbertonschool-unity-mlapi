using TMPro;

using Unity.Netcode;

using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _text;
	[SerializeField] private Button _serverButton;
	[SerializeField] private Button _hostButton;
	[SerializeField] private Button _clientButton;

	private void Awake()
	{
		_serverButton.onClick.AddListener(() =>
		{
			NetworkManager.Singleton.StartServer();
			_text.text = "SERVER";
		});

		_hostButton.onClick.AddListener(() =>
		{
			NetworkManager.Singleton.StartHost();
			_text.text = "HOST";
		});

		_clientButton.onClick.AddListener(() =>
		{
			NetworkManager.Singleton.StartClient();
			_text.text = "CLIENT";
		});
	}
}
