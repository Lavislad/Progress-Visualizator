using Microsoft.Data.Sqlite;
using ProgressVisualizer.Models;

namespace ProgressVisualizer.Data
{
    public class ChartRepository
    {
        private readonly DBManager db;

        public ChartRepository(DBManager db)
        {
            this.db = db;
        }

        // =========================================================
        // ДОБАВЛЕНИЕ ГРАФИКА
        // =========================================================

        public int Add(Chart chart)
        {
            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO Charts
                (
                    Name,
                    Description,
                    XAxisName,
                    XAxisType,
                    YAxisName,
                    YAxisUnit,
                    CreatedDate
                )
                VALUES
                (
                    @name,
                    @description,
                    @xAxisName,
                    @xAxisType,
                    @yAxisName,
                    @yAxisUnit,
                    @createdDate
                );

                SELECT last_insert_rowid();
            ";

            command.Parameters.AddWithValue(
                "@name",
                chart.Name);

            command.Parameters.AddWithValue(
                "@description",
                chart.Description);

            command.Parameters.AddWithValue(
                "@xAxisName",
                chart.XAxisName);

            command.Parameters.AddWithValue(
                "@xAxisType",
                chart.XAxisType);

            command.Parameters.AddWithValue(
                "@yAxisName",
                chart.YAxisName);

            command.Parameters.AddWithValue(
                "@yAxisUnit",
                chart.YAxisUnit);

            command.Parameters.AddWithValue(
                "@createdDate",
                chart.CreatedDate.ToString("O"));

            long id = (long)command.ExecuteScalar();

            return (int)id;
        }

        // =========================================================
        // ПОЛУЧЕНИЕ ВСЕХ ГРАФИКОВ
        // =========================================================

        public List<Chart> GetAll()
        {
            List<Chart> charts = new List<Chart>();

            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    Id,
                    Name,
                    Description,
                    XAxisName,
                    XAxisType,
                    YAxisName,
                    YAxisUnit,
                    CreatedDate
                FROM Charts
                ORDER BY Id DESC;
            ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Chart chart = new Chart();

                chart.Id = reader.GetInt32(0);
                chart.Name = reader.GetString(1);

                chart.Description =
                    reader.IsDBNull(2)
                        ? ""
                        : reader.GetString(2);

                chart.XAxisName =
                    reader.GetString(3);

                chart.XAxisType =
                    reader.GetString(4);

                chart.YAxisName =
                    reader.GetString(5);

                chart.YAxisUnit =
                    reader.IsDBNull(6)
                        ? ""
                        : reader.GetString(6);

                chart.CreatedDate =
                    DateTime.Parse(
                        reader.GetString(7));

                charts.Add(chart);
            }

            return charts;
        }

        // =========================================================
        // ПОЛУЧЕНИЕ ГРАФИКА ПО ID
        // =========================================================

        public Chart? GetById(int id)
        {
            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    Id,
                    Name,
                    Description,
                    XAxisName,
                    XAxisType,
                    YAxisName,
                    YAxisUnit,
                    CreatedDate
                FROM Charts
                WHERE Id = @id;
            ";

            command.Parameters.AddWithValue(
                "@id",
                id);

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            Chart chart = new Chart();

            chart.Id = reader.GetInt32(0);
            chart.Name = reader.GetString(1);

            chart.Description =
                reader.IsDBNull(2)
                    ? ""
                    : reader.GetString(2);

            chart.XAxisName =
                reader.GetString(3);

            chart.XAxisType =
                reader.GetString(4);

            chart.YAxisName =
                reader.GetString(5);

            chart.YAxisUnit =
                reader.IsDBNull(6)
                    ? ""
                    : reader.GetString(6);

            chart.CreatedDate =
                DateTime.Parse(
                    reader.GetString(7));

            return chart;
        }

        // =========================================================
        // ИЗМЕНЕНИЕ ГРАФИКА
        // =========================================================

        public void Update(Chart chart)
        {
            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE Charts
                SET
                    Name = @name,
                    Description = @description,
                    XAxisName = @xAxisName,
                    XAxisType = @xAxisType,
                    YAxisName = @yAxisName,
                    YAxisUnit = @yAxisUnit
                WHERE Id = @id;
            ";

            command.Parameters.AddWithValue(
                "@id",
                chart.Id);

            command.Parameters.AddWithValue(
                "@name",
                chart.Name);

            command.Parameters.AddWithValue(
                "@description",
                chart.Description);

            command.Parameters.AddWithValue(
                "@xAxisName",
                chart.XAxisName);

            command.Parameters.AddWithValue(
                "@xAxisType",
                chart.XAxisType);

            command.Parameters.AddWithValue(
                "@yAxisName",
                chart.YAxisName);

            command.Parameters.AddWithValue(
                "@yAxisUnit",
                chart.YAxisUnit);

            command.ExecuteNonQuery();
        }

        // =========================================================
        // УДАЛЕНИЕ ГРАФИКА
        // =========================================================

        public void Delete(int id)
        {
            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                DELETE FROM Charts
                WHERE Id = @id;
            ";

            command.Parameters.AddWithValue(
                "@id",
                id);

            command.ExecuteNonQuery();
        }

        // =========================================================
        // ПОИСК ГРАФИКОВ
        // =========================================================

        public List<Chart> Search(string searchText)
        {
            List<Chart> charts = new List<Chart>();

            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    Id,
                    Name,
                    Description,
                    XAxisName,
                    XAxisType,
                    YAxisName,
                    YAxisUnit,
                    CreatedDate
                FROM Charts
                WHERE Name LIKE @search
                ORDER BY Name;
            ";

            command.Parameters.AddWithValue(
                "@search",
                "%" + searchText + "%");

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Chart chart = new Chart();

                chart.Id = reader.GetInt32(0);
                chart.Name = reader.GetString(1);

                chart.Description =
                    reader.IsDBNull(2)
                        ? ""
                        : reader.GetString(2);

                chart.XAxisName =
                    reader.GetString(3);

                chart.XAxisType =
                    reader.GetString(4);

                chart.YAxisName =
                    reader.GetString(5);

                chart.YAxisUnit =
                    reader.IsDBNull(6)
                        ? ""
                        : reader.GetString(6);

                chart.CreatedDate =
                    DateTime.Parse(
                        reader.GetString(7));

                charts.Add(chart);
            }

            return charts;
        }
    }
}