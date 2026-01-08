using ModuleContracts;

namespace HelloModule
{
    public class GreetingModule : IModule
    {
        public string Name => "Greeting Module";

        public string Execute(string input)
        {
            return $"안녕하세요, {input}! 동적 모듈에서 응답했습니다.";
        }
    }
}
