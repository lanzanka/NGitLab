using NGitLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGitLab
{
    public interface ILabelClient
    {
        /// <summary>
        /// Return a list of labels for a project.
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<Label>> ForProject(int projectId);

        /// <summary>
        /// Return a specified label from the project or null;
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        Task<Label> GetLabel(int projectId, string Name);

        /// <summary>
        /// Create a new label for a project.
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        Task<Label> CreateAsync(LabelCreate label);

        /// <summary>
        /// Edit the contents of an existing label.
        /// </summary>
        Task<Label> EditAsync(LabelEdit label);

        /// <summary>
        /// Delete a label from the project.
        /// </summary>
        Task DeleteAsync(LabelDelete label);
    }
}
