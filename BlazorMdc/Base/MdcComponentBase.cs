﻿//
//  2020-03-31  Mark Stega
//              Added ClassMapper/Class & StyleMapper/Style
//
//  2020-04-13  Mark Stega
//              Reworked 
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMdc
{
    public abstract class MdcComponentBase : ComponentBase
    {
        [CascadingParameter] protected MdcCascadingDefaults CascadingDefaults { get; set; } = new MdcCascadingDefaults();

        /// <summary>
        /// Gets or sets a collection of additional attributes that will be applied to the created element.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object> UnmatchedAttributes { get; set; }
        
        /// <summary>
        /// Gets whether the component is disabled.
        /// </summary>
        [Parameter] public bool Disabled { get; set; } = false;


        protected ClassMapper ClassMapper { get; } = new ClassMapper();

        protected StyleMapper StyleMapper { get; } = new StyleMapper();

        internal AttributeMapper AttributeMapper { get; } = new AttributeMapper();




        protected virtual async Task InitializeMdcComponent() => await Task.CompletedTask;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await InitializeMdcComponent();
            }
        }

        
        protected MdcComponentBase()
        {
            ClassMapper.Get(() => Class);

            StyleMapper.Get(() => Style);
        }

        /// <summary>
        /// Specifies one or more classnames for an DOM element.
        /// </summary>
        [Parameter]
        public string Class { get; set; }


        /// <summary>
        /// Specifies an inline style for an DOM element.
        /// </summary>
        [Parameter]
        public string Style { get; set; }
    }
}
