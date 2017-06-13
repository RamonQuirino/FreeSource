using System.Collections.Generic;

namespace FreeSource.Portal.ViewModels
{
    public abstract class AbstractViewModel
    {
        public abstract bool IsValid();
        public IList<string> Errors { get; set; }
    }
}