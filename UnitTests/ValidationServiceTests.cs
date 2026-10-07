using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgressVisualizer.Models;
using ProgressVisualizer.Services;

namespace UnitTests
{
    [TestClass]
    public class ValidationServiceTests
    {
        private ValidationService validation;

        [TestInitialize]
        public void Setup()
        {
            validation = new ValidationService();
        }


        // -------------------------------------------------------
        // UT-01
        // Проверка корректного создания графика
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateChart_ValidChart_ReturnsTrue()
        {
            Chart chart = new Chart
            {
                Name = "Прогресс обучения",
                Description = "Изменение количества изученных тем",
                XAxisName = "Неделя",
                XAxisType = "Number",
                YAxisName = "Изученные темы",
                YAxisUnit = "шт."
            };

            bool result =
                validation.ValidateChart(chart);

            Assert.IsTrue(result);
        }


        // -------------------------------------------------------
        // UT-02
        // Проверка числового X
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateDataPoint_NumberX_ValidNumber_ReturnsTrue()
        {
            DataPoint point = new DataPoint
            {
                XValue = "10",
                YValue = 25
            };

            bool result =
                validation.ValidateDataPoint(
                    point,
                    "Number");

            Assert.IsTrue(result);
        }


        // -------------------------------------------------------
        // UT-03
        // Числовой X не должен принимать текст
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateDataPoint_NumberX_Text_ReturnsFalse()
        {
            DataPoint point = new DataPoint
            {
                XValue = "abc",
                YValue = 25
            };

            bool result =
                validation.ValidateDataPoint(
                    point,
                    "Number");

            Assert.IsFalse(result);
        }


        // -------------------------------------------------------
        // UT-04
        // Проверка текстового X
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateDataPoint_TextX_AnyText_ReturnsTrue()
        {
            DataPoint point = new DataPoint
            {
                XValue = "Первая неделя",
                YValue = 25
            };

            bool result =
                validation.ValidateDataPoint(
                    point,
                    "Text");

            Assert.IsTrue(result);
        }


        // -------------------------------------------------------
        // UT-05
        // Проверка даты X
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateDataPoint_DateX_ValidDate_ReturnsTrue()
        {
            DataPoint point = new DataPoint
            {
                XValue = "07.10.2026",
                YValue = 25
            };

            bool result =
                validation.ValidateDataPoint(
                    point,
                    "Date");

            Assert.IsTrue(result);
        }


        // -------------------------------------------------------
        // UT-06
        // Дата X не должна принимать произвольный текст
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateDataPoint_DateX_InvalidDate_ReturnsFalse()
        {
            DataPoint point = new DataPoint
            {
                XValue = "Не дата",
                YValue = 25
            };

            bool result =
                validation.ValidateDataPoint(
                    point,
                    "Date");

            Assert.IsFalse(result);
        }


        // -------------------------------------------------------
        // UT-07
        // Проверка числового Y
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateY_Number_ReturnsTrue()
        {
            bool result =
                validation.ValidateY("125.5");

            Assert.IsTrue(result);
        }


        // -------------------------------------------------------
        // UT-08
        // Y не должен принимать текст
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateY_Text_ReturnsFalse()
        {
            bool result =
                validation.ValidateY("abc");

            Assert.IsFalse(result);
        }


        // -------------------------------------------------------
        // UT-09
        // Название графика обязательно
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateChart_EmptyName_ReturnsFalse()
        {
            Chart chart = new Chart
            {
                Name = "",
                XAxisName = "Неделя",
                XAxisType = "Number",
                YAxisName = "Прогресс"
            };

            bool result =
                validation.ValidateChart(chart);

            Assert.IsFalse(result);
        }


        // -------------------------------------------------------
        // UT-10
        // Значение X обязательно
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateDataPoint_EmptyX_ReturnsFalse()
        {
            DataPoint point = new DataPoint
            {
                XValue = "",
                YValue = 25
            };

            bool result =
                validation.ValidateDataPoint(
                    point,
                    "Number");

            Assert.IsFalse(result);
        }


        // -------------------------------------------------------
        // UT-11
        // Название оси X обязательно
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateChart_EmptyXAxisName_ReturnsFalse()
        {
            Chart chart = new Chart
            {
                Name = "Тестовый график",
                XAxisName = "",
                XAxisType = "Number",
                YAxisName = "Прогресс"
            };

            bool result =
                validation.ValidateChart(chart);

            Assert.IsFalse(result);
        }


        // -------------------------------------------------------
        // UT-12
        // Недопустимый тип X
        // -------------------------------------------------------

        [TestMethod]
        public void ValidateChart_InvalidXAxisType_ReturnsFalse()
        {
            Chart chart = new Chart
            {
                Name = "Тестовый график",
                XAxisName = "X",
                XAxisType = "Unknown",
                YAxisName = "Y"
            };

            bool result =
                validation.ValidateChart(chart);

            Assert.IsFalse(result);
        }
    }
}