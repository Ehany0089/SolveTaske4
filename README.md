Reflection هو ميزة في C# تسمح للبرنامج إنه يفحص الكود والـ Types أثناء تشغيل البرنامج (Runtime).
أهم استخدامات Reflection
1. فحص الكلاسات والخصائص أثناء التشغيل.
2. بناء أنظمة Serialization.
3. إنشاء Dependency Injection Containers.
4. بناء Testing Frameworks.
5. اكتشاف الـ Attributes الموجودة على الكلاسات.


2. protected internal
ده Access Modifierبيحدد مين يقدر يوصلـ 
معناه:


protected OR internal

أي أن الوصول مسموح في إحدى الحالتين:
- من داخل نفس الـ Assembly.
- من داخل الكلاس نفسه أو أي Class وارث منه، حتى لو كان في Assembly آخر.

3. private protected
ده كمان Access Modifier، لكنه أكثر تقييدًا.

معناه إن الوصول مسموح فقط من:
- داخل نفس الـ Class.
- داخل الكلاسات التي ترث منه (Derived Classes).
- بشرط أن تكون داخل نفس الـ Assembly.
يعني لازم يتحقق الشرطان معًا: Inheritance وSame Assembly. 
Microsoft Learn+1
