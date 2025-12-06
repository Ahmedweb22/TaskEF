# How We Can Add new Index?
# باستخدام الdata anotation لو عايز احدد property معينه واعملها Index بعملها زى المثال الاتى :
[Index(nameof(Url))]
public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
}
# طب لو عايز اخليها Unique بعمل زى المثال الاتى واخليها ب True :
[Index(nameof(Url), IsUnique = true)]
public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
}
# طب لو عندى كذا property عايز اعملهم Index اى بمعنى اصح Composite Index هنفذ زى المثال الاتى:
[Index(nameof(FirstName), nameof(LastName))]
public class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
# ملحوظه: انا بحط ال data anotation الخاصه بالIndex فوق ال class مش فوق ال property
#                                            --------------------------------------------------------------------------------------------------------------------
# طب بال Fluent API باجى فى كلاس ApplicationDbContext و اجى فى ال Method بتاعت OnModelCreating وانفذ الاتى زى ما اتعودنا :
modelBuilder.Entity<Blog>()
    .HasIndex(b => b.Url);
# طب لو  Composite Index بنفذ الاتى:
modelBuilder.Entity<Person>()
    .HasIndex(p => new { p.FirstName, p.LastName });
# ملحوظه: حتة ال new  البشمهندس كان شرحها فى السيشن الاخيره
# How We deal with inheritance processes?
# ال EF بيدعم الوراثه لكن بعدة انماط و هم 3 انماط هنتكلم عنهم باستفاضه :
# اول نمط وهو Table‑per‑Hierarchy (TPH) :كل أنواع الوراثة base و derived تُخزَّن في جدول واحد في DB و هو جدول واحد يحتوي على أعمدة لكل الخاصيات من كل الفئات و عمود discriminator يحدد نوع كل صف و بيستخدم لما يكون عندك تسلسل وراثة بسيط، وعايز أقل جداول أداء جيد و ده مثال عليه :
public class Person
{
    public int Id { get; set; }
    public string FullName { get; set; }
}
public class Student : Person
{
    public DateTime EnrollmentDate { get; set; }
}
public class Teacher : Person
{
    public DateTime HireDate { get; set; }
}
 وباجى فى Application DbContext بحط ال Tables بتاعتى عادى
 public DbSet<Person> People { get; set; }
public DbSet<Student> Students { get; set; }
public DbSet<Teacher> Teachers { get; set; }
# وبكدا هنفعل ال TPH تلقاْءى
# تانى نمط و هو Table‑per‑Type (TPT) : كل فئة في الوراثة سواء base أو derived تاخد جدول مستقل في DB و كل جدول derived يحتوي FK يشير لجدول base و بيستخدم لما كل فئة ليها حقول مختلفة كثير ولا عايز قاعدة مرتبة بدون أعمدة Nullable كثيرة و ده مثال عليه :
public class Person
{
    public int Id { get; set; }
    public string FullName { get; set; }
}
public class Student : Person
{
    public DateTime EnrollmentDate { get; set; }
}
public class Teacher : Person
{
    public DateTime HireDate { get; set; }
}
 وباجى فى Application DbContext و اشتغل بال Fluent API عشان اعمل كل جدول لوحده و باجى فى ال Method بتاعت OnModelCreating وانفذ الاتى :
 
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Person>().ToTable("People");
    modelBuilder.Entity<Student>().ToTable("Students");
    modelBuilder.Entity<Teacher>().ToTable("Teachers");
}
# تالت نمط و هو Table‑per‑Concrete‑Type (TPC) :كل فئة “concrete” (غير abstract) تاخد جدول مستقل، والجدول يحتوي كل الحقول للفئة و الحقول الموروثة و ما فيش جدول للفئة base لو كانت abstract و ده مثال عليه : 
public abstract class Person
{
    public int Id { get; set; }
    public string FullName { get; set; }
}
public class Student : Person
{
    public DateTime EnrollmentDate { get; set; }
}
public class Teacher : Person
{
    public DateTime HireDate { get; set; }
}
 وباجى فى Application DbContext و اشتغل بال Fluent API برضو : 
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Student>().UseTpcMappingStrategy();
    modelBuilder.Entity<Teacher>().UseTpcMappingStrategy();
}



