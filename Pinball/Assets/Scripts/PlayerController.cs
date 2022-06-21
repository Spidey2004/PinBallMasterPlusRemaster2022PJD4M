using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Guarda uma referência para os controles que criamos no InputAction
    private GameControls _gameControls;
    // Guarda uma referência para o PlayerInput, que é quem conecta o dispositivo de controle ao código
    private PlayerInput _playerInput;
    // Referência para a Câmera Principal (main) do jogo
    private Camera _mainCamera;
    // Guardar o movimento que está sendo lido do controle do jogador
    private Vector2 _moveInput;
    // Guarda a referêcia para o componente de física do jogador, que usaremos para mover o jogador
    private Rigidbody _rigidbody;
    private bool _isGrounded;
    
    
    // Velocidade que o jogador vai se mover
    public float _moveMultiplier;
    public float maxVelocity;
    public float rayDistance;
    public LayerMask layerMask;
    public float jumpForce;

    // Chamada quando o objeto é desativado
    private void OnEnable()
    {
        // Instancia um novo objeto da classe GameControls
        _gameControls = new GameControls();
        
        //Associa à variável, o componente PlayerInput presente no objeto do jogador na Unity
        _playerInput = GetComponent<PlayerInput>();
        
        // Associa à variavel, o componente Rigdbody presente no objeto do jogador na Unity
        _rigidbody = GetComponent<Rigidbody>();
        
        //Associa á variave o valor presente na variável main da classe Camera, que é a camera principal do jogo
        _mainCamera = Camera.main;
        
        // Delegate para a função que é chamada quando uma tecla/botão no controle é apertada
        _playerInput.onActionTriggered += OnActionTriggered;
    }
    // Chamada quando o objeto é desativado
    private void OnDisable()
    {
        // Desinscrever o delegate
        _playerInput.onActionTriggered -= OnActionTriggered;
    }

    // Delegate para adicionarmos funcionalidade quando o jogador aperta um botão 
    private void OnActionTriggered(InputAction.CallbackContext obj)
    {
        // caso a ação seja de mover, passamos o valor que está vindo nao obj, que, como definimos no Input Action, é um Vector2, para a variável _moveInput
        // como definimos no InputAction, é um Vector2, para a variável _moveInput
        if (obj.action.name.CompareTo(_gameControls.PlayerControls.Movement.name) == 0)
        {
            _moveInput = obj.ReadValue<Vector2>();
        }
        if (obj.action.name.CompareTo(_gameControls.PlayerControls.Jump.name) == 0)
        {
            if (obj.performed) Jump();
        }
    }
    
    // Executa a movimentação do jogador através da fisica
    private void Move()
    {
        Vector3 canForword = _mainCamera.transform.forward;
        Vector3 canRight = _mainCamera.transform.right;

        canForword.y = 0;
        canRight.y = 0;
        // Usamos Addforce para adicionar uma força gradual para o jogador, quando mais tempo segurarmos a tecla mais rápido a bolinha vai
        _rigidbody.AddForce(
                             // Multiplicamos o input que move o jogador para a frente pelo vetor que aponta para a frente da camera
                             (canForword * _moveInput.y+
                              canRight * _moveInput.x)
                            // Multiplica o input que move o jogador para a frente pelo vetor que aponta para a direita da camera
                            // Multiplica esse resultado pela velocidade e pela variavel de deltaTime
                             *_moveMultiplier * Time.fixedDeltaTime);
        Debug.Log("Esta movendo");
    }
    // Função que é executada todo loop de fisica da unity
    private void FixedUpdate()
    {
        // Quando a física for atualizada, chama a função de mover
        Move();
        LimitVelocity();
    }

    private void LimitVelocity()
    {
        Vector3 velocity = _rigidbody.velocity;
        
        if(Mathf.Abs(velocity.x) > maxVelocity) velocity.x = Mathf.Sign(velocity.x) * maxVelocity;
        velocity.z = Mathf.Clamp(velocity.z, -maxVelocity, maxVelocity);

        _rigidbody.velocity = velocity;
    }

    private void CheckGround()
    {
        RaycastHit collision;

        if (Physics.Raycast(transform.position, Vector3.down, out collision, rayDistance, layerMask))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        CheckGround();
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position,Vector3.down * rayDistance,Color.red);
    }
}


