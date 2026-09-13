
---

# Common DataTypes (C# vs. SQL Server vs. PostgreSQL)

| C# Type         | SQL Server         | PostgreSQL                 | Recommended |
| --------------- | ------------------ | -------------------------- | ----------- |
| `bool`          | `bit`              | `boolean`                  | ✅           |
| `byte`          | `tinyint`          | `smallint`                 | ✅           |
| `short`         | `smallint`         | `smallint`                 | ✅           |
| `int`           | `int`              | `integer`                  | ✅           |
| `long`          | `bigint`           | `bigint`                   | ✅           |
| `float`         | `real`             | `real`                     | ⚠️ Rare     |
| `double`        | `float`            | `double precision`         | ⚠️ Rare     |
| `decimal`       | `decimal(p,s)`     | `numeric(p,s)`             | ✅           |
| `char`          | `char(1)`          | `char(1)`                  | ⚠️ Rare     |
| `string`        | `nvarchar(n)`      | `varchar(n)`               | ✅           |
| `string`        | `nvarchar(max)`    | `text`                     | ✅           |
| `DateTime`      | `datetime2`        | `timestamp with time zone` | ✅           |
| `DateOnly`      | `date`             | `date`                     | ✅           |
| `TimeOnly`      | `time`             | `time`                     | ✅           |
| `TimeSpan`      | `time`             | `interval`                 | ⚠️          |
| `Guid`          | `uniqueidentifier` | `uuid`                     | ✅           |
| `byte[]`        | `varbinary(max)`   | `bytea`                    | ✅           |
| `enum (string)` | `nvarchar`         | `text`                     | ✅           |
| `JsonDocument`  | `nvarchar(max)`    | `jsonb`                    | ⭐           |
| `List<T>`       | JSON               | JSON                       | ⭐           |
| Spatial types   | `geometry`         | `geometry` (PostGIS)       | Rare        |

---
