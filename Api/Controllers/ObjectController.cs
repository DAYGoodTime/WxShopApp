﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using Service.Services;
using WxsAppShop.Entity.Base;

namespace Api.Controllers
{
    [Route("api/object")]
    [ApiController]
    public class ObjectController : Controller
    {
        private readonly IVoteServices voteServices;
        private readonly IVoiceServices voiceServices;
        private readonly ITopicServices topicServices;
        private readonly INewsServices newsServices;

        public ObjectController(
            IVoiceServices _voiceServices,
            IVoteServices _voteServices,
            ITopicServices _topicServices,
            INewsServices _newsServices
            )
        {
            voiceServices = _voiceServices;
            voteServices = _voteServices;
            topicServices = _topicServices;
            newsServices = _newsServices;
        }
        /// <summary>
        /// 获取所有的“话题”版块
        /// </summary>
        /// <returns></returns>
        [Route("getTopics")]
        [HttpGet]
        public IActionResult GetTopics()
        {
            return Json(RespRsult.OK(topicServices.GetAll()));
        }
        [Route("getVotes")]
        [HttpGet]
        public IActionResult GetVotes()
        {
            return Json(RespRsult.OK(voteServices.GetAll()));
        }
        [Route("getVoice")]
        [HttpGet]
        public IActionResult GetVoice()
        {
            return Json(RespRsult.OK(voiceServices.GetAll()));
        }
        [Route("getNews")]
        [HttpGet]
        public IActionResult GetNews()
        {
            return Json(RespRsult.OK(newsServices.GetAll()));
        }

    }
}
