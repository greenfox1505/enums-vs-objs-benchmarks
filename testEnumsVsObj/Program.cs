using System;
using System.Diagnostics;




TestEnums.Main();

class TestEnums
{
    class State
    {
        virtual public int getValue()
        {
            return 0;
        }
    };

    class A : State
    {
        override public int getValue()
        {
            return 1;
        }
    };
    class B : State
    {
        override public int getValue()
        {
            return 2;
        }
    };
    class C : State
    {
        override public int getValue()
        {
            return 3;
        }
    };
    class D : State
    {
        override public int getValue()
        {
            return 4;
        }
    };
    class E : State
    {
        override public int getValue()
        {
            return 5;
        }
    };
    class F : State
    {
        override public int getValue()
        {
            return 6;
        }
    };

    enum STATES
    {
        BASE,
        A,
        B,
        C,
        D,
        E,
        F
    };

    static int test(STATES x)
    {
        switch (x)
        {
            case STATES.BASE:
                return 0;
            case STATES.A:
                return 1;
            case STATES.B:
                return 2;
            case STATES.C:
                return 3;
            case STATES.D:
                return 4;
            case STATES.E:
                return 5;
            case STATES.F:
                return 6;
        }
        return -1;
    }

    static public void Main()
    {
        Int64 count = 1_000_000_000;
        for (int i = 0; i < 10; i++)
        {
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                totalState(count);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine("Enum Runtime :{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
            }
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                totalObj(count);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                Console.WriteLine("Objs Runtime :{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
            }
        }
    }

    static Int64 totalState(Int64 count)
    {
        STATES[] stateEnums = {
            STATES.A,
            STATES.B,
            STATES.C,
            STATES.D,
            STATES.E,
            STATES.F
        };
        count = count / stateEnums.LongLength;
        Int64 total = 0;
        for (Int64 i = 0; i < count; i++)
        {
            foreach (STATES s in stateEnums)
            {
                total += test(s);
            }
        }
        return total;
    }

    static Int64 totalObj(Int64 count)
    {
        State[] stateObj = {
        new A(),
        new B(),
        new C(),
        new D(),
        new E(),
        new F(),
        };
        Int64 total = 0;
        count = count / stateObj.LongLength;
        for (Int64 i = 0; i < count; i++)
        {
            foreach (State s in stateObj)
            {
                total += s.getValue();
            }
        }
        return total;
    }


}
