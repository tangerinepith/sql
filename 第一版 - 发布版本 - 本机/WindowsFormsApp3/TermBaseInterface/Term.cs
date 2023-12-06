namespace TermBaseInterface
{
	internal class Term
	{
		private string EN_Conflict, ZH_Conflict, SH_Conflict;

		public Term()
		{
			this.EN_Conflict = "";
			this.ZH_Conflict = "";
			this.SH_Conflict = "";
		}
		public Term(string en, string zh, string sh)
		{
			this.EN_Conflict = en;
			this.ZH_Conflict = zh;
			this.SH_Conflict = sh;
		}
        
		public virtual string EN
		{
			get
			{
				return this.EN_Conflict;
			}
			set
			{
				this.EN_Conflict = value;
			}
		}
		public virtual string ZH
		{
			get
			{
				return this.ZH_Conflict;
			}
			set
			{
				this.ZH_Conflict = value;
			}
		}
		public virtual string SH
		{
			get
			{
				return this.SH_Conflict;
			}
			set
			{
				this.SH_Conflict = value;
			}
		}

	}

}