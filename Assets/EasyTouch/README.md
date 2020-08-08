# 自制 EasyTouch 插件版本记录
## 2020年08月03日 10:40:16
#### v0.0.0.1
###### 实现了简易的摇杆功能，**仅能控制对象移动**，使用方法：<br>
**将 Prefabs 目录中的 EasyTouch 拖入画布即可** <br>

##### 提供两个设置角色方向的委托方法：
 1. 设置角色方向：EasyTouch.SetDir(Action<Vector2\> cb); 
 2. 清除角色方向：EsayTouch.UnDir(Action<Vector2\> cb);
