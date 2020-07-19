using System.Collections.Generic;
using System.Text;

namespace HF_API_AutoGen
{
    internal class BlockConditional : BlockStatement
    {
        /// <summary>
        /// Gets or sets the indentation (recursively updating into inner blocks).
        /// </summary>
        public override int Indentation
        {
            get => base.Indentation;
            set
            {
                base.Indentation = value;
                InnerBlocks.ForEach(block => block.Indentation = NextIndent);
            }
        }

        /// <summary>
        /// The list of block statements within this block (only applicable for conditional/using types).
        /// </summary>
        public List<BlockStatement> InnerBlocks { get; } = new List<BlockStatement>();

        /// <summary>
        /// The next indentation.
        /// </summary>
        private int NextIndent => Indentation + 1;

        /// <summary>
        /// Constructs a new <see cref="BlockStatement"/>.
        /// </summary>
        /// <param name="expression">The expression, or condition (for conditional types) of block.</param>
        /// <param name="indentation">The indentation level of the statement.</param>
        /// <param name="innerBlocks">The inner block statements.</param>
        public BlockConditional(string expression, int indentation = 0, params BlockStatement[] innerBlocks)
            : base(expression, indentation)
        {
            InnerBlocks.AddRange(innerBlocks);
        }

        /// <summary>
        /// Creates and adds an inner block statement.
        /// </summary>
        /// <param name="expression">The expression to create the <see cref="BlockStatement"/> with.</param>
        /// <param name="type">The <see cref="BlockStatementType"/> of the block.</param>
        /// <returns>A reference to the <see cref="BlockStatement"/> added.</returns>
        public BlockStatement AddInner(string expression) => AddInner(new BlockStatement(expression, NextIndent));

        /// <summary>
        /// Creates and adds an inner block statement.
        /// </summary>
        /// <param name="block">The <see cref="BlockStatement"/> to add.</param>
        /// <returns>A reference to the <see cref="BlockStatement"/> added.</returns>
        public BlockStatement AddInner(BlockStatement block)
        {
            block.Indentation = NextIndent;
            InnerBlocks.Add(block);
            return block;
        }

        /// <summary>
        /// Generates the conditional code.
        /// </summary>
        /// <returns></returns>
        public override string Generate()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{Tab}if ({Expression})");
            builder.AppendLine($"{Tab}{{");
            InnerBlocks.ForEach(block => builder.AppendLine(block.Generate()));
            builder.AppendLine($"{Tab}}}");
            return builder.ToString();
        }
    }
}
