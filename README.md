# AutoMapper
In certian projects, we find a need to map from one object to another.
Rather than writing plumbing code to do that for each class, we may simply use AutoMapper

# Instructions
1)Import namespace AutoMapper

2)Inherit classes to be mapped from AutoMap.IMappable

#Example

    class Model1: AutoMap.IMappable
    {
        public int Foo1;

        public string Foo2;

        public int Foo3 { get; set; }
    }

    class Model2: AutoMap.IMappable
    {
        public int Foo1;

        public string Foo2;

        public int Foo3 { get; set; }

        public int Foo4;
    }
    
    Model1 m1 = new Model1 { Foo1 = 1, Foo2 = "Foo2", Foo3 = 2 };

    Model2 m2 = new Model2 { };    

#To Auto-map :
Simply say 

            m1.Map(m2);

#If after auto-mapping, we need to override few values or to even set values that couldn't be auto-mapped:
Simply use ContinueWith after auto-mapping


    m1.Map(m2).ContinueWith(()=> {
                m2.Foo3 = 3;
                m2.Foo4 = 4;
            });

  


