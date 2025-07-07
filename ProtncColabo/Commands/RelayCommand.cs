using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProtncColabo.Commands
{
    // MVVM에서 명령 처리를 위해 ICommand를 구현한 클래스
    public class RelayCommand : ICommand
    {
        // 실행 로직을 저장
        private readonly Action _execute;

        // 실행 가능 여부 판단 로직 저장 (없으면 항상 true)
        private readonly Func<bool> _canExecute;

        // 생성자 - 필수 실행 메서드와 선택적 조건 메서드 받음
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // WPF가 명령 상태를 자동 갱신할 수 있도록 이벤트 연결
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // 명령 실행 가능 여부 반환
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        // 명령 실행
        public void Execute(object parameter) => _execute();
    }
}
