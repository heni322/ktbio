import { FileEdit, CheckCircle, Truck, ShoppingCart, Users, FolderTree } from 'lucide-react';
import { Card } from '@/components/ui/card';

interface StatCardProps {
  icon: React.ElementType;
  label: string;
  value: number;
  color: string;
}

function StatCard({ icon: Icon, label, value, color }: StatCardProps) {
  return (
    <Card className="p-4 flex items-center gap-4 hover:shadow-md transition-shadow">
      <div className={`p-3 rounded-lg ${color}`}>
        <Icon className="h-6 w-6 text-white" />
      </div>
      <div>
        <p className="text-2xl font-bold text-gray-800">{value}</p>
        <p className="text-sm text-gray-500">{label}</p>
      </div>
    </Card>
  );
}

interface DashboardStatsProps {
  stats: {
    demandeDispatching: number;
    bonDispatching: number;
    demandeRetour: number;
    bonRetour: number;
    utilisateurs: number;
    sousFamilles: number;
  };
}

export function DashboardStats({ stats }: DashboardStatsProps) {
  return (
    <div className="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-6 gap-4">
      <StatCard
        icon={FileEdit}
        label="Demande de dispatching"
        value={stats.demandeDispatching}
        color="bg-emerald-500"
      />
      <StatCard
        icon={CheckCircle}
        label="Bon de dispatching"
        value={stats.bonDispatching}
        color="bg-blue-500"
      />
      <StatCard
        icon={Truck}
        label="Demande de retour"
        value={stats.demandeRetour}
        color="bg-purple-500"
      />
      <StatCard
        icon={ShoppingCart}
        label="Bon de retour"
        value={stats.bonRetour}
        color="bg-amber-500"
      />
      <StatCard
        icon={Users}
        label="Utilisateurs"
        value={stats.utilisateurs}
        color="bg-cyan-600"
      />
      <StatCard
        icon={FolderTree}
        label="Sous-Famille"
        value={stats.sousFamilles}
        color="bg-teal-600"
      />
    </div>
  );
}
