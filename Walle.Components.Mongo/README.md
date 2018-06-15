# Walle.Components.Mongo 

## 简介

 这是一个对MongoDB驱动进行一个简单封装的类,能够快速的帮助开发人员```Code-Fisrt```快速实现业务需求.
 在下面我会给出响应的demo. 另外多说一句: 关于在什么情况下使用NoSql ,我觉得最适合的场景应该是在事件溯源架构场景下用作事件存储.

## 开始使用

DAL, Model 层引用该类库 ```Walle.Components.Mongo ```

实体类Demo:

```c#
    /// <summary>
    /// 系统用户
    /// </summary>
    public class JustUser : MongoEntityBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string WorkId { get; set; }


        /// <summary>
        /// 用户角色
        /// </summary>
        public JustUserRole Role = JustUserRole.Users;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
```

数据访问层Demo:

```c#
  public class JustUserDal: MongoDalBase<JustUser>
  {
     
  }
```

分页查询Demo:

```c#
public List<JustUser> GetUsers(int pageIndex, int pageSize, out long count, string userName = null)
{
  count = 0;
  var dal = new JustUserDal();
  Expression<Func<JustUser, bool>> expression = null;
  if (userName.IsNotNullOrEmpty())
  {
    expression = p => p.UserName.Contains(userName);
  }
  var result = dal.AsQueryable().Page<JustUser>(pageIndex, pageSize, expression);
  if (result.IsNotNull() && result.Result.HasAny())
  {
    count = result.Count;
    result.Result.ForEach(p => p.Password = string.Empty);
    return result.Result;
  }
  else
  {
    return null;
  }
}
```
