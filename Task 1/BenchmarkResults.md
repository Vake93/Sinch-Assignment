|                 Method | ElementCount |             Mean |          Error |         StdDev |           Median | Ratio | RatioSD | Allocated |
|----------------------- |------------- |-----------------:|---------------:|---------------:|-----------------:|------:|--------:|----------:|
| CountPairsByBruteForce |           10 |         34.51 ns |       0.267 ns |       0.209 ns |         34.46 ns |  1.00 |    0.00 |         - |
|    CountPairsBySorting |           10 |         34.42 ns |       0.116 ns |       0.103 ns |         34.39 ns |  1.00 |    0.01 |         - |
|    CountPairsByHashing |           10 |        108.04 ns |       1.018 ns |       0.850 ns |        108.16 ns |  3.13 |    0.03 |     336 B |
|                        |              |                  |                |                |                  |       |         |           |
| CountPairsByBruteForce |          100 |      4,571.04 ns |     114.538 ns |     337.719 ns |      4,692.30 ns |  1.00 |    0.00 |         - |
|    CountPairsBySorting |          100 |        280.63 ns |       1.731 ns |       1.534 ns |        280.40 ns |  0.06 |    0.00 |         - |
|    CountPairsByHashing |          100 |        969.82 ns |       4.888 ns |       4.082 ns |        969.08 ns |  0.22 |    0.01 |   2,792 B |
|                        |              |                  |                |                |                  |       |         |           |
| CountPairsByBruteForce |         1000 |    348,834.33 ns |   6,956.287 ns |  14,209.852 ns |    342,107.42 ns |  1.00 |    0.00 |         - |
|    CountPairsBySorting |         1000 |      3,801.19 ns |      39.288 ns |      36.750 ns |      3,803.49 ns |  0.01 |    0.00 |         - |
|    CountPairsByHashing |         1000 |      9,649.95 ns |     191.715 ns |     528.039 ns |      9,399.78 ns |  0.03 |    0.00 |  27,712 B |
|                        |              |                  |                |                |                  |       |         |           |
| CountPairsByBruteForce |        10000 | 33,530,000.55 ns | 146,040.218 ns | 121,950.196 ns | 33,514,842.86 ns | 1.000 |    0.00 |      34 B |
|    CountPairsBySorting |        10000 |     45,601.13 ns |     803.596 ns |     751.685 ns |     45,526.81 ns | 0.001 |    0.00 |         - |
|    CountPairsByHashing |        10000 |    191,875.87 ns |   1,095.898 ns |     915.124 ns |    191,560.35 ns | 0.006 |    0.00 | 258,275 B |