﻿using System.Collections.Generic;

namespace DeanerySystem.WebUI.Models.Education.Schedule 
{
	public class LessonGroupModel 
	{
		public LessonGroupModel(int groupId) 
		{
			GroupId = groupId;
			Lessons = new List<LessonModel>();
		}

		public int GroupId { get; set; }
		public List<LessonModel> Lessons { get; set; }
	}
}
