using System.Text;


namespace AdventOfCodeTDD
{
    public class Calibration
    {

        static uint ToNum(string line)
        {
            return Convert.ToUInt32(line.Replace('.', '0').Replace('#', '1').PadLeft(32, '0'), 2);
        }
        static bool PowerOfTwo(uint a)
        {
            return a != 0 && (a & (a - 1)) == 0;
        }
        static bool DiffByOneBit(uint a, uint b)
        {
            return PowerOfTwo(a ^ b);
        }

        static bool IsReflection(uint[] lines, int a, int b)
        {
            while (a >= 0 && b < lines.Length)
            {
                if (lines[a--] != lines[b++])
                    return false;
            }
            return true;
        }

        static bool IsReflectionLine(uint[] arr, int a, int b)
        {
            return arr[a] == arr[b] && IsReflection(arr, a, b);
        }

        static int ReflectionInArray(uint[] arr)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (IsReflectionLine(arr, j, j + 1))
                    return j + 1;
            }

            return 0;
        }

        static uint[] GetColumns(string[] block)
        {
            uint[] cols = new uint[block[0].Length];
            for (int c = 0; c < block[0].Length; c++)
            {
                StringBuilder col = new StringBuilder();
                for (int r = 0; r < block.Length; r++)
                    col.Append(block[r][c]);
                cols[c] = ToNum(col.ToString());
            }

            return cols;
        }

        static int CheckForRowReflect(string[] block)
        { return ReflectionInArray(block.Select(ToNum).ToArray());
        }
        static int CheckForColumnReflection(string[] block)
        { return ReflectionInArray(GetColumns(block)); }
        public static void Main()
        {
            
            var lines = readFile(@"C:\Users\input13.txt");
            var input = calculateInput(lines);
            var part1Answer = calculate_part1(input);
            var part2Answer = calculate_part2(input);
        }
        
        public static string readFile(string fileName)
        {
            
            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception();
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
            var lines = File.ReadAllText(fileName);
            return lines;
        }

        public static List<string[]> calculateInput(string lines)
        {
            if (lines==null || lines.Count()==0)
            {
                throw new InvalidDataException();
            }
         var input = lines.Split($"{Environment.NewLine}{Environment.NewLine}").Select(b => b.Split(Environment.NewLine)).ToList();
            return input;
        }

        public static int calculate_part1(List<string[]> input)
        {
            int part1Answer = input.Select(CheckForRowReflect).Sum() * 100 + input.Select(CheckForColumnReflection).Sum();
            return part1Answer;
        }
        public static int calculate_part2(List<string[]> input)
        {
            var part2Answer = input.Select(CheckBlock).Sum();
            return part2Answer;
        }
        static List<(int, int)> LinesOffByOne(uint[] nums)
        {
            var pairs = new List<(int, int)>();

            for (int r = 0; r < nums.Length - 1; r++)
            {
                for (int r2 = r + 1; r2 < nums.Length; r2++)
                {
                    if (DiffByOneBit(nums[r], nums[r2]))
                        pairs.Add((r, r2));
                }
            }

            return pairs;
        }

        static string[] SubColumn(string[] block, int c1, int c2)
        {
            string[] tweaked = new string[block.Length];

            for (int j = 0; j < block.Length; j++)
            {
                var sb = new StringBuilder(block[j]);
                sb[c2] = block[j][c1];
                tweaked[j] = sb.ToString();
            }

            return tweaked;
        }

        static int CheckBlock(string[] block)
        {
            var rows = block.Select(ToNum).ToArray();
            List<(int, int)> rowSubs = LinesOffByOne(rows);

            int oldReflectRow = CheckForRowReflect(block);
            foreach (var s in rowSubs)
            {
                var b = block.Clone() as string[];
                b[s.Item2] = block[s.Item1];
                rows = b.Select(ToNum).ToArray();

                var candidates = new List<int>();
                for (int r = 0; r < rows.Length - 1; r++)
                {
                    if (r + 1 != oldReflectRow && rows[r] == rows[r + 1])
                    {
                        if (IsReflection(rows, r, r + 1))
                            return (r + 1) * 100;
                    }
                }
            }

            int oldReflectCol = CheckForColumnReflection(block);
            var colSubs = LinesOffByOne(GetColumns(block));
            foreach (var s in colSubs)
            {
                var b = SubColumn(block, s.Item1, s.Item2);
                var cols = GetColumns(b);
                var candidates = new List<int>();
                for (int c = 0; c < cols.Length - 1; c++)
                {
                    if (c + 1 != oldReflectCol && cols[c] == cols[c + 1])
                    {
                        if (IsReflection(cols, c, c + 1))
                            return c + 1;
                    }
                }
            }
            return 0;
        }
    }
}