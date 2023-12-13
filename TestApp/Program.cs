var matrixToCheck1 = new[]
{
    new[] { '1', '0', '1', '1', '1' },
    new[] { '1', '0', '1', '1', '1' },
    new[] { '1', '1', '1', '1', '1' },
    new[] { '1', '0', '0', '1', '0' },
    new[] { '1', '0', '0', '1', '0' },
};

var matrixToCheck2 = new[]
{
    new[] { '1', '0', '0', '1', '1' },
    new[] { '1', '1', '1', '1', '1' },
    new[] { '1', '1', '1', '1', '1' },
    new[] { '1', '1', '1', '1', '0' },
    new[] { '1', '0', '0', '1', '0' },
};

var matrixToCheck3 = new[]
{
    new[] { '1', '0', '1', '0', '1' },
    new[] { '1', '1', '1', '1', '1' },
    new[] { '1', '1', '1', '1', '1' },
    new[] { '0', '1', '1', '1', '1' },
    new[] { '1', '1', '1', '1', '1' },
};

var matrixToCheck4 = new[]
{
    new[] { '0', '1', '1', '1' },
    new[] { '0', '1', '0', '0' },
    new[] { '1', '1', '1', '1' },
    new[] { '0', '0', '1', '1' },
};

var matrixToCheck5 = new[]
{
    new[] { '0', '0'},
    new[] { '0', '0'}
};

var matrixToCheck6 = new[]
{
    new[] { '0', '0', '0'},
    new[] { '0', '1', '0'},
    new[] { '0', '0', '0'}
};

Console.WriteLine(Solution(matrixToCheck1));
Console.WriteLine(Solution(matrixToCheck2));
Console.WriteLine(Solution(matrixToCheck3));
Console.WriteLine(Solution(matrixToCheck4));
Console.WriteLine(Solution(matrixToCheck5));
Console.WriteLine(Solution(matrixToCheck6));

int Solution(char[][] matrix)
{
    var maxSquareLength = GetMatrixMaxLength(matrix, 0, 0, 0);
    return maxSquareLength * maxSquareLength;
}

int GetMatrixMaxLength(char[][] matrix, int lengthMaxCurrent, int x, int y)
{
    var nextStep = 1;
    if (matrix[y][x] == '1')
    {
        var lengthCurrent = 1;
        while (CheckColumn(matrix, lengthCurrent, x, y) && CheckRow(matrix, lengthCurrent, x, y))
        {
            lengthCurrent++;
        }

        nextStep = lengthCurrent;

        if (lengthMaxCurrent < lengthCurrent)
            lengthMaxCurrent = lengthCurrent;
    }

    var lengthMaxX = 0;
    var lengthMaxY = 0;
    
    if (x + nextStep < matrix.Length)
        lengthMaxX = GetMatrixMaxLength(matrix, lengthMaxCurrent, x + nextStep, y);

    if (y + nextStep < matrix.Length)
        lengthMaxY = GetMatrixMaxLength(matrix, lengthMaxCurrent, x, y + nextStep);

    var lengthMaxSubMatrix = lengthMaxX > lengthMaxY ? lengthMaxX : lengthMaxY;
    
    return lengthMaxSubMatrix > lengthMaxCurrent ? lengthMaxSubMatrix : lengthMaxCurrent;
        
}

bool CheckRow(char[][] matrix, int length, int x, int y)
{
    if (y + length >= matrix.Length)
        return false;
    
    for (var i = x; i < x + length; i++)
    {
        if (matrix[y + length][i] == '0')
        {
            return false;
        }
    }

    return true;
}

bool CheckColumn(char[][] matrix, int length, int x, int y)
{
    if (x + length >= matrix.Length)
        return false;
    
    for (var i = y; i < y + length; i++)
    {
        if (matrix[i][x + length] == '0')
        {
            return false;
        }
    }

    return true;
}