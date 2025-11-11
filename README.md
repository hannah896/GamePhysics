# GamePhysics
게임물리와 상호작용 최종 프로젝트
8번출구 류 게임.
추후 빌드하여 플레이 링크 첨부 예정.
시연영상 추가 예정.

# 코드 컨벤션
## camelCase    
private 필드명, 멤버변수등 

ex) private int speed = 1;

## PascalCase   
메서드 명, public 변수

ex) private void Attack(int damageValue), public GameObject PrefabObject

### 내부 변수 선언시 private 꼭 붙여주기!
ex) private Start()
### /// public 메서드는 xml주석 무조건 작성하기
ex) 작성예시

      /// public 메서드는 xml주석 무조건 작성하기
      private void Method(GameObject gameObject)
      {

            _gameObject = gameObject;

      }





###  float 소수점 까지
ex) private float _number = 1.0f; ( 소수점 까지 적기 )






# 파일 컨벤션
## 씬 네이밍
실제 게임에 사용할 씬은 PascalCase

ex) StartScene

기능 구현중일때는 개인 씬은 snake_Case(언더바 붙이기)

ex) PHN_Trap, JYJ_Entity

## 파일 명
스크립트명, 오브젝트 등등 모두 PascalCase 로 작성!!
ex) ScoreUI.cs









# 커밋 컨벤션
      [Feat] " "      ⇒ 새로운 기능 추가 시 
      
      [WIP] " "       ⇒ 일단 작업중인거 냅다 커밋할 때
      
      [Fix] " "       ⇒ 버그 수정시
      
      [Refactor] " "  ⇒ 코드의 구조 / 형식 갈아엎을 때
      
      [Chore] " "     ⇒ 코드 기능 구현말고 관리작업(깃허브같은 것)할 때
      
      [Style] " "     ⇒ 줄간격이나 칸정렬 수정 시, 혹은 주석만 추가한 경우

