namespace BlazorApp1.Dto
{
    public class InboxRequestDto
    {
        public string Subject { get; set; } = "طلب معلم";
        public string SenderId { get; set; } = string.Empty;
        public string ReceiverId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;// المادة
        public string EducationSystem { get; set; } = string.Empty; // النظام التعليمي
        public string Grade { get; set; } = string.Empty;// الصف الدراسي
        public string SchoolName { get; set; } = string.Empty;// اسم المدرسة
        public string Region { get; set; } = string.Empty; // المنطقة
        public string LearningGoal { get; set; } = string.Empty;// ما هو هدف التعلم
        public string Learner { get; set; } = string.Empty;// من المتعلم
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
    }

}
