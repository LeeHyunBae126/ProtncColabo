using ProtncColabo.Commands;
using ProtncColabo.Models;
using ProtncColabo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProtncColabo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // LiteDB 서비스 인스턴스 생성 (DB 접근용)
        private readonly LiteDbService _dbService = new LiteDbService();

        // 출퇴근 로그를 담는 컬렉션, UI 바인딩용 ObservableCollection 사용
        public ObservableCollection<AttendanceLog> Logs { get; set; } = new ObservableCollection<AttendanceLog>();

        // 사용자 입력 사번 저장용 필드
        private string _employeeId;

        // 사번 프로퍼티, 변경 시 UI에 알림
        public string EmployeeId
        {
            get => _employeeId;
            set => SetProperty(ref _employeeId, value);
        }

        // 스캔 버튼 클릭 시 실행될 커맨드
        public ICommand ScanCommand => new RelayCommand(OnScan);

        // 생성자: 초기 로그 로드
        public MainViewModel()
        {
            LoadLogs();
        }

        // 스캔 처리 메서드
        private void OnScan()
        {
            // 사번이 비어있으면 처리 중단
            if (string.IsNullOrWhiteSpace(EmployeeId)) return;

            // 출근 로그 생성 (현재는 무조건 출근으로 처리)
            var log = new AttendanceLog
            {
                EmployeeId = EmployeeId,
                ScanTime = DateTime.Now,
                Status = "출근" // 추후 출근/퇴근 자동 판별 가능
            };

            // DB에 로그 저장
            _dbService.InsertLog(log);

            // UI 로그 갱신
            LoadLogs();

            // 입력창 초기화
            EmployeeId = string.Empty;
        }

        // DB에서 모든 로그를 불러와 UI 컬렉션 갱신
        private void LoadLogs()
        {
            Logs.Clear();
            var list = _dbService.GetAllLogs();
            foreach (var log in list)
            {
                Logs.Add(log);
            }
        }
    }
}
