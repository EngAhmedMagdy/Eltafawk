using BlazorApp1.Dto;
using EltafawkPlatform.Dto;
using EltafawkPlatform.Models;
using MongoDB.Bson;

namespace EltafawkPlatform.Mapper
{
    public static class InboxMessageMapper
    {
        public static InboxMessageDto ToDto(this InboxMessageModel model)
        {
            return new InboxMessageDto
            {
                //Id = model.Id.ToString(),
                SenderId = model.SenderId,
                ReceiverId = model.ReceiverId,
                Subject = model.Subject,
                Body = model.Body,
                IsRead = model.IsRead,
                SentAt = model.SentAt,
                Replies = model.Replies.Select(r => new ReplyDto
                {
                    SenderId = r.SenderId,
                    Body = r.Body,
                    //SentAt = r.SentAt
                }).ToList()
            };
        }

        public static InboxMessageModel ToModel(this InboxMessageDto dto)
        {
            return new InboxMessageModel
            {
                Id = string.IsNullOrEmpty(dto.Id) ? ObjectId.GenerateNewId() : new ObjectId(dto.Id),
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
                Subject = dto.Subject,
                Body = dto.Body,
                IsRead = dto.IsRead,
                SentAt = dto.SentAt,
                Replies = dto.Replies.Select(r => new ReplyModel
                {
                    SenderId = r.SenderId,
                    Body = r.Body,
                    //SentAt = r.SentAt
                }).ToList()
            };
        }
        public static InboxMessageModel MapToMessage(this InboxRequestDto dto)
        {
            return new InboxMessageModel
            {
                Id = ObjectId.GenerateNewId(),
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
                Subject = dto.Subject,
                Body = $@"
                        المادة: {dto.Course}
                        النظام التعليمي: {dto.EducationSystem}
                        الصف الدراسي: {dto.Grade}
                        اسم المدرسة: {dto.SchoolName}
                        المنطقة: {dto.Region}
                        هدف التعلم: {dto.LearningGoal}
                        من المتعلم: {dto.Learner}
                        الاسم: {dto.FirstName} {dto.LastName}
                        رقم الهاتف: {dto.CountryCode} {dto.Phone}
                        البريد الإلكتروني: {dto.Email}".Trim(),
                SentAt = DateTime.UtcNow,
                IsRead = false
            };
        }

    }

}
