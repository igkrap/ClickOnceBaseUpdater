# ClickOnceBaseUpdater

C# 7.3 / .NET Framework 4.7.2 기반 WPF 예제 솔루션입니다.

## 솔루션 구성

- `MainApplication`: 메인 WPF GUI. 업데이트 토스트(예/아니오) 표시 후 Updater 실행.
- `Updater`: 메인 앱 종료 후 업데이트를 수행하고 메인 앱을 재시작하는 콘솔 앱.
- `ModuleContracts`: 모듈 인터페이스 정의.
- `Modules/HelloModule`: 동적으로 로딩되는 샘플 모듈.

## 실행 흐름

1. MainApplication에서 **업데이트 확인** 버튼 클릭.
2. 예/아니오 토스트 표시.
3. 예 선택 시 MainApplication 종료 후 Updater 실행.
4. Updater에서 업데이트 작업(샘플) 수행 후 MainApplication 재실행.

## 모듈 동적 로딩

MainApplication은 실행 폴더의 `Modules/HelloModule.dll`을 로드합니다.
빌드 후 해당 DLL을 `MainApplication.exe` 옆에 `Modules` 폴더를 만들어 복사하세요.

## ClickOnce 설정

각 프로젝트의 csproj에 ClickOnce 게시용 속성(Install/UpdateEnabled 등)이 포함되어 있습니다.
실제 게시 시 Visual Studio의 **게시** 메뉴를 사용하세요.
