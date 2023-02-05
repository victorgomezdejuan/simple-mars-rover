using SimpleMarsRover.Src;

namespace SimpleMarsRover.Test;

public class SimpleMarsRoverTests
{
    private MarsRover rover;

    public SimpleMarsRoverTests()
    {
        rover = new MarsRover();
    }

    [Fact]
    public void StartingPosition()
    {
        AssertPosition(0, 0);
        AssertDirection('N');
    }

    [Fact]
    public void R_DirectionE()
    {
        Execute('R');

        AssertDirection('E');
    }

    [Fact]
    public void RR_DirectionS()
    {
        Execute("RR");
        
        AssertDirection('S');
    }

    [Fact]
    public void RRR_DirectionW()
    {
        Execute("RRR");
        
        AssertDirection('W');
    }

    [Fact]
    public void RRRR_DirectionN()
    {
        Execute("RRRR");
        
        AssertDirection('N');
    }

    [Fact]
    public void L_DirectionW()
    {
        Execute('L');
        
        AssertDirection('W');
    }

    [Fact]
    public void LL_DirectionS()
    {
        Execute("LL");
        
        AssertDirection('S');
    }

    [Fact]
    public void LLL_DirectionS()
    {
        Execute("LLL");
        
        AssertDirection('E');
    }

    [Fact]
    public void LLLL_DirectionS()
    {
        Execute("LLLL");
        
        AssertDirection('N');
    }

    [Fact]
    public void M_SameDirection()
    {
        Execute('M');
        
        AssertDirection('N');
    }

    [Fact]
    public void MM_SameDirection()
    {
        Execute("MM");
        
        AssertDirection('N');
    }

    [Fact]
    public void MRMR_DirectionS()
    {
        Execute("MRMR");
        
        AssertDirection('S');
    }

    [Fact]
    public void LMLML_DirectionE()
    {
        Execute("LMLML");
        
        AssertDirection('E');
    }

    [Fact]
    public void M_Position01()
    {
        Execute('M');
        
        AssertPosition(0, 1);
    }

    [Fact]
    public void MM_Position02()
    {
        Execute("MM");
        
        AssertPosition(0, 2);
    }

    [Fact]
    public void M10_Position00()
    {
        Execute(Times('M', 10));
        
        AssertPosition(0, 0);
    }

    [Fact]
    public void RM_Position10()
    {
        Execute("RM");
        
        AssertPosition(1, 0);
    }

    [Fact]
    public void RMM_Position20()
    {
        Execute("RMM");
        
        AssertPosition(2, 0);
    }

    [Fact]
    public void RM10_Position00()
    {
        Execute('R' + Times('M', 10));

        AssertPosition(0, 0);
    }

    [Fact]
    public void LM_Position90()
    {
        Execute("LM");
        
        AssertPosition(9, 0);
    }

    [Fact]
    public void LMM_Position80()
    {
        Execute("LMM");
        
        AssertPosition(8, 0);
    }

    [Fact]
    public void LM10_Position00()
    {
        Execute('L' + Times('M', 10));
        
        AssertPosition(0, 0);
    }

    [Fact]
    public void LLM_Position09()
    {
        Execute("LLM");
        
        AssertPosition(0, 9);
    }

    [Fact]
    public void LLMM_Position08()
    {
        Execute("LLMM");
        
        AssertPosition(0, 8);
    }

    [Fact]
    public void LLM10_Position00()
    {
        Execute("LL" + Times('M', 10));
        
        AssertPosition(0, 0);
    }

    [Fact]
    public void MMRMMLM_Position23N()
    {
        Execute("MMRMMLM");
        
        AssertPosition(2, 3, 'N');
    }

    [Fact]
    public void M3RM8LM7_Position80N()
    {
        Execute(
            Times('M', 3) +
            'R' +
            Times('M', 8) +
            'L' +
            Times('M', 7));
        
        AssertPosition(8, 0, 'N');
    }

        [Fact]
    public void LM4RRRM8_Position62S()
    {
        Execute(
            'L' +
            Times('M', 4) +
            "RRR" +
            Times('M', 8));
        
        AssertPosition(6, 2, 'S');
    }

    private void Execute(string commands)
    {
        foreach(char command in commands)
            Execute(command);   
    }

    private void Execute(char command)
    {
        rover.Execute(command);
    }

    private void AssertDirection(char direction)
    {
        Assert.Equal(direction, rover.CurrentPosition[4]);
    }

    private void AssertPosition(int x, int y)
    {
        Assert.Equal($"{x}:{y}", rover.CurrentPosition[0..3]);
        Assert.Equal(5, rover.CurrentPosition.Length);
    }

    private void AssertPosition(int x, int y, char direction)
    {
        Assert.Equal($"{x}:{y}:{direction}", rover.CurrentPosition);
    }

    private static string Times(char command, int times)
    {
        return new string(command, times);
    }
}