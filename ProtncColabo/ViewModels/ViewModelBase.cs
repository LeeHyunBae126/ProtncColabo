using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProtncColabo.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        // INotifyPropertyChanged 이벤트 선언
        public event PropertyChangedEventHandler PropertyChanged;

        // 프로퍼티 변경 시 호출, 바인딩된 UI에 변경 알림 전달
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        // 프로퍼티 값 변경 시 필드 업데이트 및 변경 알림 처리
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propName = null)
        {
            // 기존 값과 같으면 변경하지 않고 false 반환
            if (Equals(field, value)) return false;

            // 값 변경
            field = value;

            // 변경 알림 이벤트 발생
            OnPropertyChanged(propName);

            return true; // 변경 완료를 알림
        }
    }
}
