using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Unity Input System을 사용하기 위한 네임스페이스

public class Player : MonoBehaviour
{
    // 플레이어 움직임을 제어하는 변수들
    public Vector2 inputVec; // 플레이어 입력을 저장합니다.
    public float speed; // 플레이어의 이동 속도

    Rigidbody2D rigid; // 플레이어에 부착된 Rigidbody2D 컴포넌트에 대한 참조

    SpriteRenderer spriter;
    Animator anim;
    void Start()
    {
        // 플레이어 오브젝트에 부착된 Rigidbody2D 컴포넌트를 가져와서 참조를 초기화합니다.
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // void Update()
    // {
    //     // 플레이어의 입력을 받아옵니다.
    //     // Input.GetAxisRaw("Horizontal")은 왼쪽(-1), 가만히(0), 오른쪽(1) 화살표 키를 기준으로 합니다.
    //     // Input.GetAxisRaw("Vertical")은 아래쪽(-1), 가만히(0), 위쪽(1) 화살표 키를 기준으로 합니다.
    //     inputVec.x = Input.GetAxisRaw("Horizontal");
    //     inputVec.y = Input.GetAxisRaw("Vertical");
    // }

    void FixedUpdate()
    {
        // 입력, 속도, 시간을 기반으로 다음 위치 벡터를 계산합니다.
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        // 플레이어 Rigidbody를 다음 위치로 이동시킵니다.
        rigid.MovePosition(rigid.position + nextVec);
    }

    // Input System에서 "Move" 액션에 대한 이벤트 처리 메서드
    void OnMove(InputValue value)
    {
        // 입력 값을 받아와서 inputVec에 저장합니다.
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0){
            spriter.flipX = inputVec.x < 0;
        }
    }
}