namespace SimpleMarsRover.Src;
public class MarsRover
{
    private const int PlateauMinIndex = 0;
    private const int DirectionMinIndex = PlateauMinIndex;
    private const int DirectionMaxIndex = 3;
    private const int PlateauMaxIndex = 9;
    private static readonly char[] Directions = new char[4] { 'N', 'E', 'S', 'W' };
    private int x, y, directionIndex;

    public MarsRover()
        => x = y = directionIndex = PlateauMinIndex;

    public string CurrentPosition { get { return $"{x}:{y}:{Direction}"; } }

    private char Direction { get { return Directions[directionIndex]; } }

    public void Execute(char command)
    {
        switch(command)
        {
            case 'R':
                RotateRight();
                break;
            case 'L':
                RotateLeft();
                break;
            case 'M':
                Move();
                break;
        }
    }
   
    private void RotateLeft()
    {
        if (directionIndex == DirectionMinIndex)
            directionIndex = DirectionMaxIndex;
        else
            directionIndex--;
    }

    private void RotateRight()
    {
        if (directionIndex < DirectionMaxIndex)
            directionIndex++;
        else
            directionIndex = DirectionMinIndex;
    }

     private void Move()
    {
        switch(Direction)
        {
            case 'N':
                MoveNorth();
                break;
            case 'E':
                MoveEast();
                break;
            case 'W':
                MoveWest();
                break;
            case 'S':
                MoveSouth();
                break;
        }
    }

    private void MoveNorth()
        => Increment(ref y);

    private void MoveEast()
        => Increment(ref x);

    private void MoveWest()
        => Decrement(ref x);

    private void MoveSouth()
        => Decrement(ref y);

    private void Increment(ref int coordinate)
    {
        if (coordinate < PlateauMaxIndex)
            coordinate++;
        else
            coordinate = PlateauMinIndex;
    }

    private void Decrement(ref int coordinate)
    {
        if (coordinate > PlateauMinIndex)
            coordinate--;
        else
            coordinate = PlateauMaxIndex;
    }
}