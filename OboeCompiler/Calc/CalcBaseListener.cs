//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Calc.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419


using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ICalcListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class CalcBaseListener : ICalcListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.prog"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProg([NotNull] CalcParser.ProgContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.prog"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProg([NotNull] CalcParser.ProgContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.assign"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssign([NotNull] CalcParser.AssignContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.assign"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssign([NotNull] CalcParser.AssignContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.ifstatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIfstatement([NotNull] CalcParser.IfstatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.ifstatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIfstatement([NotNull] CalcParser.IfstatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.elsestatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterElsestatement([NotNull] CalcParser.ElsestatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.elsestatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitElsestatement([NotNull] CalcParser.ElsestatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.whilestatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterWhilestatement([NotNull] CalcParser.WhilestatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.whilestatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitWhilestatement([NotNull] CalcParser.WhilestatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.forstatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterForstatement([NotNull] CalcParser.ForstatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.forstatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitForstatement([NotNull] CalcParser.ForstatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.boolexpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolexpr([NotNull] CalcParser.BoolexprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.boolexpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolexpr([NotNull] CalcParser.BoolexprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.mathexpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMathexpr([NotNull] CalcParser.MathexprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.mathexpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMathexpr([NotNull] CalcParser.MathexprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterValue([NotNull] CalcParser.ValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitValue([NotNull] CalcParser.ValueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.id"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterId([NotNull] CalcParser.IdContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.id"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitId([NotNull] CalcParser.IdContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.varid"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVarid([NotNull] CalcParser.VaridContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.varid"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVarid([NotNull] CalcParser.VaridContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.memberid"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMemberid([NotNull] CalcParser.MemberidContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.memberid"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMemberid([NotNull] CalcParser.MemberidContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="CalcParser.mathfunc"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMathfunc([NotNull] CalcParser.MathfuncContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="CalcParser.mathfunc"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMathfunc([NotNull] CalcParser.MathfuncContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}