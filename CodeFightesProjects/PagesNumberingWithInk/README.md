#[PagesNumberingWithInk](https://codefights.com/arcade/code-arcade/labyrinth-of-nested-loops/pdw3izd7SpMTBJqSy)

<div class="markdown"><p>You work in a company that prints and publishes books. You are responsible for designing the page numbering mechanism in the printer. You know how many digits a printer can print with the leftover ink. Now you want to write a function to determine what the last page of the book is that you can number given the <code>current</code> page and <code>numberOfDigits</code> left. A page is considered numbered if it has the full number printed on it (e.g. if we are working with page <code>102</code> but have ink only for two digits then this page will not be considered numbered).</p>
<p>It's guaranteed that you can number the <code>current</code> page, and that you can't number the last one in the book.</p>
<p><strong>Example</strong></p>
<ul>
<li>
<p>For <code>current = 1</code> and <code>numberOfDigits = 5</code>, the output should be<br>
<code>pagesNumberingWithInk(current, numberOfDigits) = 5</code>.</p>
<p>The following numbers will be printed: <code>1</code>, <code>2</code>, <code>3</code>, <code>4</code>, <code>5</code>.</p>
</li>
<li>
<p>For <code>current = 21</code> and <code>numberOfDigits = 5</code>, the output should be<br>
<code>pagesNumberingWithInk(current, numberOfDigits) = 22</code>.</p>
<p>The following numbers will be printed: <code>21</code>, <code>22</code>.</p>
</li>
<li>
<p>For <code>current = 8</code> and <code>numberOfDigits = 4</code>, the output should be<br>
<code>pagesNumberingWithInk(current, numberOfDigits) = 10</code>.</p>
<p>The following numbers will be printed: <code>8</code>, <code>9</code>, <code>10</code>.</p>
</li>
</ul>
<p><strong>Input/Output</strong></p>
<ul>
<li><strong>[time limit] 6000ms (cs)</strong></li>
</ul>
<ul>
<li>
<p><strong>[input] integer current</strong></p>
<p>A positive integer, the number on the current page which is not yet printed.</p>
<p><em>Constraints:</em><br>
<code>1 ≤ current ≤ 1000</code>.</p>
</li>
<li>
<p><strong>[input] integer numberOfDigits</strong></p>
<p>A positive integer, the number of digits which your printer can print.</p>
<p><em>Constraints:</em><br>
<code>1 ≤ numberOfDigits ≤ 1000</code>.</p>
</li>
<li>
<p><strong>[output] integer</strong></p>
<p>The last printed page number.</p>
</li>
</ul>
</div>