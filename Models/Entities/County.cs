﻿using LC.Infrastructure.Database.Interface;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LC.Models.Entities
{
    /// <summary>
    /// 縣市
    /// </summary>
    [Comment("縣市")]
    public class County : ARecord
    {
        /// <summary>
        /// 名稱
        /// </summary>        
        [StringLength(20)]
        [Comment("名稱")]
        public required string Name { get; set; } = "";

        /// <summary>
        /// 縣市代號
        /// </summary>        
        [StringLength(5)]
        [Comment("縣市代號")]
        public required string CountyID { get; set; } = "";

        /// <summary>
        /// 縣市代碼
        /// </summary>        
        [StringLength(10)]
        [Comment("縣市代碼")]
        public required string CountyCode { get; set; } = "";

        /// <summary>
        /// 名稱
        /// </summary>        
        [StringLength(20)]
        [Comment("英文名稱")]
        public required string EngName { get; set; } = "";

        /// <summary>
        /// 座標點位
        /// </summary>
        [Column(TypeName = "geometry")]
        [Comment("座標點位")]
        public Geometry? Geom { get; set; }
    }
}
