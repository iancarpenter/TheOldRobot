namespace TheOldRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();

            for (int index = 0; index < robot.Commands.Length; index++)
            {
                Console.WriteLine($"What command do you want to add? {index} of {robot.Commands.Length}");
                Console.WriteLine("on");
                Console.WriteLine("off");
                Console.WriteLine("north");
                Console.WriteLine("south");
                Console.WriteLine("east");
                Console.WriteLine("west");

                string? input = Console.ReadLine();
                RobotCommand newCommand = input switch
                {
                    "on"    => new OnCommand(),
                    "off"   => new OffCommand(),
                    "north" => new NorthCommand(),
                    "south" => new SouthCommand(),
                    "east"  => new EastCommand(),
                    "west"  => new WestCommand(),
                };
                robot.Commands[index] = newCommand;
            }

            Console.WriteLine();

            robot.Run();
        }
    }

    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPowered { get; set; }
        public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
        public void Run()
        {
            foreach (RobotCommand? command in Commands)
            {
                command?.Run(this);
                Console.WriteLine($"[{X} {Y} {IsPowered}]");
            }
        }
    }

    public abstract class RobotCommand
    {
        public abstract void Run(Robot robot);
    }

    public class OnCommand : RobotCommand
    {
        public override void Run(Robot robot) => robot.IsPowered = true;        
    }

    public class OffCommand : RobotCommand
    {
        public override void Run(Robot robot) => robot.IsPowered = false;        
    }

    public class NorthCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
                robot.Y++;
        }                            
    }

    public class SouthCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
                robot.Y--;
        }
    }

    public class EastCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
                robot.X++;
        }
    }

    public class WestCommand : RobotCommand
    {
        public override void Run(Robot robot)
        {
            if (robot.IsPowered)
                robot.X--;
        }
    }
}

