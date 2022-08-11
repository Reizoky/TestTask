using System;

namespace TestProg
{
	public class Auto
	{
		public string type;
		public double avgConsumption; //Расход на 100км
		public double fuelVolume = 0; //Максимальный объем бака
		public double speed;
		protected double coeffPassenger = 0;
		protected double coeffCargo = 0;

		public Auto()
		{
			type = "неопределен";
			avgConsumption = -1;
			fuelVolume = -1;
			speed = -1;
		}

		/// <summary>
		/// Вычисление расстояния по топливу
		/// </summary>
		/// <param name="fuel">Количество топливо</param>
		/// <returns>Расстояние в км</returns>
		public double GetPath(double fuel = -1)
		{
			return (fuel == -1 ? fuelVolume : fuel) / avgConsumption * 100;
		}

		/// <summary>
		/// Сколько автомобиль может проехать на полном баке топлива 
		/// </summary>
		/// <returns>Расстояние в км</returns>
		public string Path()
		{
			return $@"Автомобиль может проехать на полном баке {GetPath()} км";
		}
		/// <summary>
		/// Сколько автомобиль может проехать на остаточном количестве топлива в баке
		/// </summary>
		/// <param name="fuel">Количество топливо</param>
		/// <returns>Расстояние в км</returns>
		public string Path(double fuel)
		{
			return $@"Автомобиль может проехать с текущим запасом топлива {GetPath(fuel)} км";
		}
		/// <summary>
		/// Сколько автомобиль может проехать на полном баке топлива с учетом пассажиров и веса
		/// </summary>
		/// <returns></returns>
		public string PathWithPassengerAndCargo()
		{
			return $@"Автомобиль может проехать {GetPath() * (1 - coeffCargo - coeffPassenger)} км с учетом пассажиров и груза на полном баке";
		}

		/// <summary>
		/// Время для преодоления расстояния до пункта назначения
		/// </summary>
		/// <param name="fuel">Текущее количество топлива</param>
		/// <param name="distanse">Расстояние до пункта назначения</param>
		/// <returns>Время до пункта назначения</returns>
		public string Time(double fuel, double distanse)
		{
			if (GetPath(fuel) > distanse)
				return $@"Автомобиль не доедет до точки назначения с указанным количеством топлива";
			else
				return $@"Автомобиль доедет до точки назначения за {distanse / speed}";
		}
	}

	public class AutoLight : Auto
	{
		int countPassenger;
		int maxPassenger;

		public AutoLight() : base()
		{
			countPassenger = 1;
			maxPassenger = 1;
		}

		/// <summary>
		/// Изменение и получение количества пассавжиров
		/// </summary>
		public int CountPassenger
		{
			get
			{
				return countPassenger;
			}
			set
			{
				if (value <= maxPassenger)
				{
					countPassenger = value;
					coeffPassenger = value * 0.06;
				}
				else
					Console.WriteLine("Количество пассажиров больше максимальной вместимости");
			}
		}
	}

	public class AutoCargo : Auto
	{
		int countCargo;
		int maxCargo;

		public AutoCargo() : base()
		{
			countCargo = 1;
			maxCargo = 1;
		}

		/// <summary>
		/// Получение или изменение груза автомобиля
		/// </summary>
		public int CountCargo
		{
			get
			{
				return countCargo;
			}
			set
			{
				if (value <= maxCargo)
				{
					countCargo = value;
					coeffCargo = value / 200 * 0.04;
				}
				else
					Console.WriteLine("Автомобиль не может принять весь груз");
			}
		}
	}

	public class AutoSport : Auto
	{ }
}
