using Microsoft.Data.Sqlite;
using ProgressVisualizer.Models;

namespace ProgressVisualizer.Data
{
    public class DataPointRepository
    {
        private readonly DBManager db;

        public DataPointRepository(DBManager db)
        {
            this.db = db;
        }

        public int Add(DataPoint point)
        {
            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO DataPoints
                (
                    ChartId,
                    XValue,
                    YValue
                )
                VALUES
                (
                    @chartId,
                    @xValue,
                    @yValue
                );

                SELECT last_insert_rowid();
            ";

            command.Parameters.AddWithValue(
                "@chartId",
                point.ChartId);

            command.Parameters.AddWithValue(
                "@xValue",
                point.XValue);

            command.Parameters.AddWithValue(
                "@yValue",
                point.YValue);

            long id = (long)command.ExecuteScalar();

            return (int)id;
        }

        public List<DataPoint> GetByChartId(int chartId)
        {
            List<DataPoint> points =
                new List<DataPoint>();

            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    Id,
                    ChartId,
                    XValue,
                    YValue
                FROM DataPoints
                WHERE ChartId = @chartId
                ORDER BY Id;
            ";

            command.Parameters.AddWithValue(
                "@chartId",
                chartId);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                DataPoint point = new DataPoint();

                point.Id =
                    reader.GetInt32(0);

                point.ChartId =
                    reader.GetInt32(1);

                point.XValue =
                    reader.GetString(2);

                point.YValue =
                    reader.GetDouble(3);

                points.Add(point);
            }

            return points;
        }

        public DataPoint? GetById(int id)
        {
            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT
                    Id,
                    ChartId,
                    XValue,
                    YValue
                FROM DataPoints
                WHERE Id = @id;
            ";

            command.Parameters.AddWithValue(
                "@id",
                id);

            using var reader =
                command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new DataPoint
            {
                Id = reader.GetInt32(0),

                ChartId = reader.GetInt32(1),

                XValue = reader.GetString(2),

                YValue = reader.GetDouble(3)
            };
        }

        public void Update(DataPoint point)
        {
            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE DataPoints
                SET
                    XValue = @xValue,
                    YValue = @yValue
                WHERE Id = @id;
            ";

            command.Parameters.AddWithValue(
                "@id",
                point.Id);

            command.Parameters.AddWithValue(
                "@xValue",
                point.XValue);

            command.Parameters.AddWithValue(
                "@yValue",
                point.YValue);

            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                DELETE FROM DataPoints
                WHERE Id = @id;
            ";

            command.Parameters.AddWithValue(
                "@id",
                id);

            command.ExecuteNonQuery();
        }

        public void DeleteByChartId(int chartId)
        {
            using var connection = db.GetConnection();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                DELETE FROM DataPoints
                WHERE ChartId = @chartId;
            ";

            command.Parameters.AddWithValue(
                "@chartId",
                chartId);

            command.ExecuteNonQuery();
        }
    }
}