using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace SLFormsApp.Behaviors
{
    public class PasswordValidator : Behavior<Entry>
    {
        private const string EmailRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

        public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(EmailValidator), false);

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.BindingContextChanged +=
              (sender, _) => BindingContext = ((BindableObject)sender).BindingContext;
            bindable.TextChanged += TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= TextChanged;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null)
            {
                return;
            }

            IsValid = Regex.IsMatch(e.NewTextValue, EmailRegex);
        }
    }
}
