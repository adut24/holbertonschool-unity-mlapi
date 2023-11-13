using Unity.Netcode;

using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent (typeof(Rigidbody))]
public class PlayerNetwork : NetworkBehaviour
{
	[SerializeField] private Rigidbody _rb;
	[SerializeField] private float _speed;
	private float _horizontalInput;
	private float _verticalInput;
	private Vector3 _moveDirection;

	private void Update()
	{
		if (!IsOwner)
			return;
		TakeInput();
	}


	private void FixedUpdate() => MovePlayer();

	private void TakeInput()
	{
		_horizontalInput = Input.GetAxisRaw("Horizontal");
		_verticalInput = Input.GetAxisRaw("Vertical");
		_moveDirection = new Vector3(_horizontalInput, 0, _verticalInput).normalized;
	}

	private void MovePlayer()
	{
		_rb.AddForce(_moveDirection * _speed * 10f, ForceMode.Force); 
		_rb.MoveRotation(Quaternion.Euler(0, Mathf.Atan2(_horizontalInput, _verticalInput) * Mathf.Rad2Deg, 0));
	}
}
