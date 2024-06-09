using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace разбор_анимации
{
    public class VM : INotifyPropertyChanged

    {
       

        private double _triangleX = 200;
        private double _triangleY = 200;
        private bool _isMoving = false; // приватное поле класса, которое хранит информацию о том, находится ли треугольник в движении или нет.
        public int angle = 0; //хранит угол поворота треугольника
        public Stopwatch Stopwatch = new Stopwatch(); //Это публичное поле класса, которое содержит экземпляр Stopwatch, используемый для измерения времени.



        public VM()
        {
            StartMoving(); //Это конструктор класса, который вызывает метод StartMoving() при создании экземпляра класса.
        }



        public double TriangleX //Это публичные свойства класса, которые хранят координаты x и y
                                //треугольника. Когда эти значения меняются, вызывается событие OnPropertyChanged для уведомления о изменениях.

        {
            get { return _triangleX; }
            set { _triangleX = value; OnPropertyChanged(nameof(TriangleX)); }
        }

        public double TriangleY
        {
            get { return _triangleY; }
            set { _triangleY = value; OnPropertyChanged(nameof(TriangleY)); }
        }



        public int Angle
        {
            get { return angle; }
            set { angle = value; OnPropertyChanged(nameof(Angle)); }
        }

       

        public ICommand ToggleMovementCommand //Это публичное свойство класса, которое возвращает новый экземпляр BindCommand, ссылающийся на метод ToggleMovement().
                                              //Это свойство используется для привязки команды в пользовательском интерфейсе.
        {
            get
            {
                Console.WriteLine(_isMoving);
                return new BindCommand(ToggleMovement);
            }
        }

       
        private void ToggleMovement()   //Это приватный метод класса, который отвечает за переключение состояния движения треугольника.
                                        //Если треугольник находится в движении, метод останавливает Stopwatch и записывает прошедшее время.
                                        //Если треугольник не находится в движении, метод запускает Stopwatch и вызывает StartMoving().
        {
            //Stopwatch.Stop();

            _isMoving = !_isMoving;

            if (_isMoving)
            {
                Stopwatch.Start();
                StartMoving();
            }
            else
            {
                Stopwatch.Stop();
                Console.WriteLine(Stopwatch.Elapsed.ToString());
            }
        }

        private async void StartMoving()
        {
            const double radius = 40; //радиус круга
            const double centerX = 200;// центр круга X
            const double centerY = 200;
            const int delay = 10;  // задержка в миллисекундах

            while (_isMoving)
            {
                angle += 2; // увеличивает угол на 2 градуча
                if (angle>=360) // если угол больше или равен 360, начинаем с 0
                {
                    angle =0;
                }
                TriangleX = centerX+radius*Math.Cos(angle * Math.PI/180); // пересчитываем координаты для движения по кругу
                TriangleY = centerY+radius*Math.Sin(angle * Math.PI/180);

                OnPropertyChanged(nameof(TriangleX)); // уведомляем об изменении координаты Х
                OnPropertyChanged(nameof(TriangleY));

                await Task.Delay(delay); // ожидаем перед следующим обновлением координат

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

