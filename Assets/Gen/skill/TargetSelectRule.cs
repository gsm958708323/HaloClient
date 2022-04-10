//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cfg.skill
{
    public enum TargetSelectRule
    {
        /// <summary>
        /// 最少总血量
        /// </summary>
        MinHPValue = 1,
        /// <summary>
        /// 最少百分比血量
        /// </summary>
        MinHPPercent = 2,
        /// <summary>
        /// 靠近目标角色的单个选择
        /// </summary>
        TargetClosestSingle = 3,
        /// <summary>
        /// 靠近某个位置的单个选择
        /// </summary>
        PositionClosestSingle = 4,
        /// <summary>
        /// 靠近目标角色的多个选择（范围选择）
        /// </summary>
        TargetClosetMultiple = 101,
        /// <summary>
        /// 靠近某个位置的多个选择（范围选择
        /// </summary>
        PositionClosestMultiple = 102,
    }
}
