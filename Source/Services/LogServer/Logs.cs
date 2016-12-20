﻿using System;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using Insight.Base.Common;
using Insight.Base.Common.Entity;
using Insight.Base.OAuth;
using Insight.Utils.Common;
using static Insight.Base.Common.Parameters;

namespace Insight.Base.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public partial class Logs : ILogs
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="code">事件代码（必须有）</param>
        /// <param name="message">事件消息，为空则使用默认消息文本</param>
        /// <param name="source">来源（可为空）</param>
        /// <param name="action">操作（可为空）</param>
        /// <param name="key">查询用的关键字段</param>
        /// <param name="userid">事件源用户ID（可为空）</param>
        /// <returns>JsonResult</returns>
        public JsonResult WriteToLog(string code, string message, string source, string action, string key, string userid)
        {
            var verify = new Compare();
            var result = Util.ConvertTo<JsonResult>(verify.Result);
            if (!result.Successful) return result;

            var gp = new GuidParse(userid);
            if (!gp.Result.Successful) 
            {
                result.BadRequest();
                return result;
            }

            var logger = new Logger(code, message, source, action, key, gp.Guid);
            var succe = logger.Write();
            if (!succe.HasValue)
            {
                result.InvalidEventCode();
                return result;
            }

            if (!succe.Value) result.DataBaseError();

            return result;
        }

        /// <summary>
        /// 新增日志规则
        /// </summary>
        /// <param name="rule">日志规则数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult AddRule(SYS_Logs_Rules rule)
        {
            const string action = "60A97A33-0E6E-4856-BB2B-322FEEEFD96A";
            var verify = new Compare(action);
            var result = Util.ConvertTo<JsonResult>(verify.Result);
            if (!result.Successful) return result;

            if (string.IsNullOrEmpty(rule.Code) || !Regex.IsMatch(rule.Code, @"^\d{6}$"))
            {
                result.InvalidEventCode();
                return result;
            }

            var level = Convert.ToInt32(rule.Code.Substring(0, 1));
            if (level <= 1 || level == 7)
            {
                result.EventWithoutConfig();
                return result;
            }

            if (Rules.Any(r => r.Code == rule.Code))
            {
                result.EventCodeUsed();
                return result;
            }

            var session = verify.Basis;
            rule.CreatorUserId = session.UserId;
            if (!Insert(rule))
            {
                result.DataBaseError();
                return result;
            }

            var log = new
            {
                UserID = session.UserId,
                Message = $"事件代码【{rule.Code}】已由{session.UserName}创建和配置为：{Util.Serialize(rule)}"
            };
            var logger = new Logger("600601", Util.Serialize(log));
            logger.Write();
            return result;
        }

        /// <summary>
        /// 删除日志规则
        /// </summary>
        /// <param name="id">日志规则ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult RemoveRule(string id)
        {
            const string action = "BBC43098-A030-46CA-A681-0C3D1ECC15AB";
            var verify = new Compare(action);
            var result = Util.ConvertTo<JsonResult>(verify.Result);
            if (!result.Successful) return result;

            var rid = new GuidParse(id).Guid;
            if (!rid.HasValue)
            {
                result.InvalidGuid();
                return result;
            }

            if (!DeleteRule(rid.Value))
            {
                result.DataBaseError();
                return result;
            }

            var session = verify.Basis;
            var log = new
            {
                UserID = session.UserId,
                Message = $"事件配置【{id}】已被{session.UserName}删除"
            };
            var logger = new Logger("600602", Util.Serialize(log));
            logger.Write();
            return result;
        }

        /// <summary>
        /// 编辑日志规则
        /// </summary>
        /// <param name="rule">日志规则数据对象</param>
        /// <returns>JsonResult</returns>
        public JsonResult EditRule(SYS_Logs_Rules rule)
        {
            const string action = "9FF1547D-2E3F-4552-963F-5EA790D586EA";
            var verify = new Compare(action);
            var result = Util.ConvertTo<JsonResult>(verify.Result);
            if (!result.Successful) return result;

            if (!Update(rule))
            {
                result.DataBaseError();
                return result;
            }

            var session = verify.Basis;
            var log = new
            {
                UserID = session.UserId,
                Message = $"事件代码【{rule.Code}】已被{session.UserName}修改为：{Util.Serialize(rule)}"
            };
            var logger = new Logger("600603", Util.Serialize(log));
            logger.Write();
            return result;
        }

        /// <summary>
        /// 获取日志规则
        /// </summary>
        /// <param name="id">日志规则ID</param>
        /// <returns>JsonResult</returns>
        public JsonResult GetRule(string id)
        {
            const string action = "E3CFC5AA-CD7D-4A3C-8900-8132ADB7099F";
            var verify = new Compare(action);
            var result = Util.ConvertTo<JsonResult>(verify.Result);
            if (!result.Successful) return result;

            var rid = new GuidParse(id).Guid;
            if (!rid.HasValue)
            {
                result.InvalidGuid();
                return result;
            }

            var rule = Rules.SingleOrDefault(r => r.ID == rid);
            if (rule == null) result.NotFound();
            else result.Success(rule);

            return result;
        }

        /// <summary>
        /// 获取全部日志规则
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult GetRules()
        {
            const string action = "E3CFC5AA-CD7D-4A3C-8900-8132ADB7099F";
            var verify = new Compare(action);
            var result = Util.ConvertTo<JsonResult>(verify.Result);
            if (!result.Successful) return result;

            if (Rules.Any()) result.Success(Rules);
            else result.NoContent();

            return result;
        }
    }
}
